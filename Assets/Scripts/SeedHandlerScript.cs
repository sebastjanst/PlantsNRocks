using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

[System.Serializable]
public class SeedHandlerScript : MonoBehaviour {
    //this script creates all the plant class objects and handles holding and planting seeds

    //set all the sprites here in the unity editor, element 0 should be a sprout and element 4 should be the fully grown plant
    private Plant Rose;
    public Sprite[] RoseSprites = new Sprite[5];

    private Plant Clover;
    public Sprite[] CloverSprites = new Sprite[5];

    private Plant Sunflower;
    public Sprite[] SunflowerSprites = new Sprite[5];

    private Plant Snowdrop;
    public Sprite[] SnowdropSprites = new Sprite[5];

    private Plant Mushroom;
    public Sprite[] MushroomSprites = new Sprite[5];

    private Plant Bonsai;
    public Sprite[] BonsaiSprites = new Sprite[5];

    private Plant CurrentSeedHeld;//the currently selected plant that the player can plant by clicking on an empty tile
    private bool HoldingSeed = false;//is any plant selected
    public CoinScript coinScript;//need coinscript to check if the player can afford a new seed
    public Image HeldSeedImg;//the fully grown plant sprite of the current seed held
    public GameObject HeldSeedDisplay;//the game object of the heldSeedImg which can be hidden if there is no seed held

    void Awake ()//Awake happens before Start, need this to make sure the class objects exist before any other script tries to access them
    {
        //decide and tweak individual plant prices, growth rate and coin rewards here:
        Rose = new Plant("Rose", 0, "A standalone rose.", 1, 250, RoseSprites);
        Clover = new Plant("Clover", 10, "A lucky clover.", 33, 100, CloverSprites);
        Sunflower = new Plant("Sunflower", 100, "A sunflower.", 155, 25, SunflowerSprites);
        Snowdrop = new Plant("Snowdrop", 1000, "A spring flower.", 2000, 15, SnowdropSprites);
        Mushroom = new Plant("Mushroom", 10000, "A mushroom.", 15000, 5, MushroomSprites);
        Bonsai = new Plant("Bonsai", 100000, "A tiny tree.", 1234567, 2, BonsaiSprites);
    }

    public Plant getPlant(int PlantNumber)//returns plant based on it's number, starting with the rose at 0
    {
        Plant PlantToReturn;
        switch (PlantNumber)
        {
            case 0: PlantToReturn = Rose; break;
            case 1: PlantToReturn = Clover; break;
            case 2: PlantToReturn = Sunflower; break;
            case 3: PlantToReturn = Snowdrop; break;
            case 4: PlantToReturn = Mushroom; break;
            case 5: PlantToReturn = Bonsai; break;
            default: PlantToReturn = Rose; break;
        }
        return PlantToReturn;
    }

    public void holdSeed(Plant BoughtSeed)//sets the seed to hold
    {
        CurrentSeedHeld = BoughtSeed;
        HeldSeedDisplay.SetActive(true);
        HeldSeedImg.sprite = BoughtSeed.Sprites[4];
        HoldingSeed = true;
    }

    public bool seedCheck()//returns true if there is currently already a seed being held
    {
        return HoldingSeed;
    }
    public Plant whatSeedIsHeld()//returns the current plant seed held
    {
        return CurrentSeedHeld;
    }

    public Plant plantSeed()//returns the current seed held and buys a new one if possible, otherwise empties hand
    {
        Plant Sprout = CurrentSeedHeld;
        if (CurrentSeedHeld.Price > coinScript.getCurrentCoins())//if you can't afford a new seed, empty hand. Otherwise autobuys a new seed for easy planting
        {
            //hides held seed graphics and empties hand
            CurrentSeedHeld = null;
            HeldSeedDisplay.SetActive(false);
            HoldingSeed = false;
        }
        else
        {
            coinScript.spendCoins(CurrentSeedHeld.Price);//buys a new seed of the current plant
        }

        return Sprout;
    }
}
