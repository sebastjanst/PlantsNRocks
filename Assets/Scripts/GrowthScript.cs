using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class GrowthScript : MonoBehaviour {

    private float WaterPercentage;//if 0 plant won't grow
    private float PlantGrowth;//0 to 100, every 25 is a new stage (new sprite) the sprite at 100 shows the plant finished growing
    public bool PlantDone;

    public SeedHandlerScript seedHandlerScript;
    private Image PlantSprite;
    private Plant PlantedPlant = new Plant();
    private Sprite[] PlantSprites;

    public GameObject WaterMeImg;

    // Use this for initialization
    void Start ()
    {
        PlantSprite = this.gameObject.GetComponent<Image>();
        setupPlant();
    }
	
    public void setupPlant()
    {
        PlantedPlant = seedHandlerScript.getPlant();
        PlantSprites = PlantedPlant.Sprites;
        PlantSprite.sprite = PlantSprites[0];

        PlantGrowth = 0;
        WaterPercentage = 100;
        WaterMeImg.SetActive(false);
        PlantDone = false;

        StartCoroutine(plantGrow());
    }

    IEnumerator plantGrow()//grows plant over time and drains water
    {
        while (PlantDone == false)
        {
            yield return new WaitForSeconds(0.5f);
            if (WaterPercentage > 0)
            {
                PlantGrowth += 5;
                WaterPercentage -= 10;

                plantSpriteCheck();
            }else WaterMeImg.SetActive(true);

            if (PlantGrowth >= 100)
            {
                PlantDone = true;//ends coroutine loop
            }
        }
    }

    public void plantSpriteCheck()//check which stage the plant is in and change sprite if needed
    {
        if(PlantGrowth >= 0 && PlantGrowth < 25)
        {
            PlantSprite.sprite = PlantSprites[0];
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
            PlantSprite.sprite = PlantSprites[4];
        }
    }

    public void plantClicked()
    {
        if (PlantDone)//collect coins
        {
            setupPlant();
        }
        else waterPlant();
    }

    public void waterPlant()
    {
        WaterPercentage = 100;
        WaterMeImg.SetActive(false);
    }
}
