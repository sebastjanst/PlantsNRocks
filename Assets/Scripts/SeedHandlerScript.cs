using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

[System.Serializable]
public class SeedHandlerScript : MonoBehaviour {

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

    private Plant CurrentSeedHeld;
    private bool HoldingSeed = false;
    public CoinScript coinScript;
    public Image HeldSeedImg;
    public GameObject HeldSeedDisplay;

    void Awake ()//Awake happens before Start
    {
        Rose = new Plant("Rose", 0, "A standalone rose.", 1, 100, RoseSprites);
        Clover = new Plant("Clover", 10, "A lucky clover.", 33, 50, CloverSprites);
        Sunflower = new Plant("Sunflower", 100, "A sunflower.", 155, 25, SunflowerSprites);
        Snowdrop = new Plant("Snowdrop", 1000, "A spring flower.", 2000, 15, SnowdropSprites);
        Mushroom = new Plant("Mushroom", 10000, "A mushroom.", 15000, 10, MushroomSprites);
        Bonsai = new Plant("Bonsai", 100000, "A tiny tree.", 1234567, 5, BonsaiSprites);
    }

    public Plant getPlant(int PlantNumber)
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

    public void holdSeed(Plant BoughtSeed)
    {
        CurrentSeedHeld = BoughtSeed;
        HeldSeedDisplay.SetActive(true);
        HeldSeedImg.sprite = BoughtSeed.Sprites[4];
        HoldingSeed = true;
    }

    public bool seedCheck()
    {
        return HoldingSeed;
    }
    public Plant whatSeedIsHeld()
    {
        return CurrentSeedHeld;
    }

    public Plant plantSeed()
    {
        Plant Sprout = CurrentSeedHeld;
        if (CurrentSeedHeld.Price > coinScript.getCurrentCoins())//if you can't afford a new seed, empty hand. Otherwise autobuys a new seed for easy planting
        {
            CurrentSeedHeld = null;
            HeldSeedDisplay.SetActive(false);
            HoldingSeed = false;
        }
        else
        {
            coinScript.spendCoins(CurrentSeedHeld.Price);
        }

        return Sprout;
    }
}
