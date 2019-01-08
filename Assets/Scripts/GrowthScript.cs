using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class GrowthScript : MonoBehaviour {

    public bool StartWithARose;//does the tile start empty or has a newly planted rose growing

    private float WaterPercentage;//if 0, the plant won't grow
    private float PlantGrowth;//0 to 100, every 25 is a new stage (new sprite) the sprite at 100 shows a fully grown plant
    public bool PlantDone;//is the plant fully grown and ready for harvest
    public bool PlantGrowing;//is the plant still growing

    public SeedHandlerScript seedHandlerScript;//the script that created and holds all the plant class objects
    public RockHandlerScript rockHandlerScript;//the script that handles bonuses from collected rocks (also holds the rock class objects)
    public CoinScript coinScript;//the script that handles the player's current coins
    public Sprite DirtSprite;//the sprite of an empty tile with no plant in it
    private Image PlantSprite;//the sprite that will be changed according to the plant and it's stage of growth
    private Plant PlantedPlant;//the class object that holds all the plant info including the sprites
    private Sprite[] PlantSprites;//all the sprites of the currently planted plant will be held here

    public GameObject WaterMeImg;//a small drop that indicates the plant has run out of water
    public Image WaterBarImg;//a bar that slowly drains as water gets used up by the plant

    // Use this for initialization
    void Start ()
    {
        PlantSprite = this.gameObject.GetComponent<Image>();

        if (StartWithARose)//if the StartWithARose box is ticked in the unity editor
        {
            seedHandlerScript.holdSeed(seedHandlerScript.getPlant(0));//plant 0 is the rose
            setupPlant();
        }else PlantSprite.sprite = DirtSprite;//if the tile is empty it starts with the dirt sprite in place of the plant sprite

        //resets water graphics
        WaterMeImg.SetActive(false);
        WaterBarImg.fillAmount = 0;//the bar is not visible if the fill is at 0
    }
	
    public void setupPlant()//sets the current tile using all the data of the currently held plant
    {
        PlantedPlant = seedHandlerScript.plantSeed();//gets the currently held plant seed
        PlantSprites = PlantedPlant.Sprites;//sets all the sprites of the plants stages of growth
        PlantSprite.sprite = PlantSprites[0];//uses the first image which should be a sprout

        PlantGrowth = 0;//growth which will increse to 100
        WaterPercentage = 100;//water starts at maximum
        WaterBarImg.fillAmount = WaterPercentage/100;//update water bar graphic, must divide by 100 since the fill ammount goes from 0 to 1
        WaterMeImg.SetActive(false);//the water me icon only appears when water is at 0
        PlantDone = false;//the plant has just been planted, so it's not done growing
        PlantGrowing = true;//it is currently gorwing and draining water

        StartCoroutine(plantGrow());//starts the coroutine that will handle the growth over time
    }

    IEnumerator plantGrow()//grows plant over time and drains water
    {
        while (PlantDone == false)//loops until plant growth reaches 100
        {
            yield return new WaitForSeconds(0.3f);
            if (WaterPercentage > 0)//water drains is there is more than 0
            {
                float AddGrowth = (PlantedPlant.GrowthRate / 100) + (rockHandlerScript.getPlantGrowthBonus()/2);
                if(AddGrowth > 25)//limit max speed from growth bonus
                    AddGrowth = 25;
                if (AddGrowth <= 0)
                    AddGrowth = 0.1f;
                PlantGrowth += AddGrowth;

                float RemoveWater = ((PlantedPlant.GrowthRate * 2) / 100) + (rockHandlerScript.getWaterDrainBonus()/2);
                if (RemoveWater <= 0)
                    RemoveWater = 1f;
                if (RemoveWater >= 25)
                    RemoveWater = 25;
                WaterPercentage -= RemoveWater;
                WaterBarImg.fillAmount = WaterPercentage / 100;

                plantSpriteCheck();
            }else WaterMeImg.SetActive(true);//if water is 0 the water droplet icon activates

            if (PlantGrowth >= 100)//checks if the plant is fully grown
            {
                //clear the water bar and icon
                WaterBarImg.fillAmount = 0;
                WaterMeImg.SetActive(false);

                PlantDone = true;//ends coroutine loop
            }
        }
    }

    public void plantSpriteCheck()//check which stage the plant is in and change sprite if needed
    {
        //these ifs check specifically between which values the plant growth is in
        if(PlantGrowth >= 0 && PlantGrowth < 25)
        {
            PlantSprite.sprite = PlantSprites[0];//starting sptite: sprout
        }
        if (PlantGrowth >= 25 && PlantGrowth < 50)
        {
            PlantSprite.sprite = PlantSprites[1];
        }
        if (PlantGrowth >= 50 && PlantGrowth < 75)
        {
            PlantSprite.sprite = PlantSprites[2];
        }
        if (PlantGrowth >= 75 && PlantGrowth < 100)
        {
            PlantSprite.sprite = PlantSprites[3];
        }
        if(PlantGrowth >= 100)
        {
            PlantSprite.sprite = PlantSprites[4];//final sprite: fully grown plant
        }
    }

    public void plantClicked()//used by the unity button script that is on each plant tile
    {
        if (PlantGrowing)//if there is a plant gorwin on this tile, the player either waters it or collects a fully grown plant
        {
            if (PlantDone)//collect coins
            {
                //give the player coins accoring to the plant type and the coin bonus from rocks 
                //(the bonus is added to the base reward by multiplying the plant reward with the rock bonus and dividing it all to try and balance the reward boost from rocks)
                coinScript.collectCoins((PlantedPlant.getReward() + ((PlantedPlant.getReward() * rockHandlerScript.getCoinRewardBonus())/2)), this.gameObject.GetComponent<Transform>().position);
                PlantSprite.sprite = DirtSprite;//clears the tile since the plant has been harvested
                PlantGrowing = false;
                WaterBarImg.fillAmount = 0;
            }
            else waterPlant();//set the water bar back to full
        }
        else if(seedHandlerScript.seedCheck()) setupPlant();//if this tile is empty check if the player is holding a valid seed to plant and plant it
    }

    public void waterPlant()//sets the water to 100 and resets the watering graphics
    {
        WaterPercentage = 100;
        WaterBarImg.fillAmount = WaterPercentage / 100;
        WaterMeImg.SetActive(false);
    }
}
