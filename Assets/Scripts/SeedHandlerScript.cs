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

    private Plant CurrentSeedHeld;
    private bool HoldingSeed = false;
    public Image HeldSeedImg;
    public GameObject HeldSeedDisplay;

    // Use this for initialization
    void Awake ()
    {
        Rose = new Plant("Rose", 0, "A standalone rose.", 1, RoseSprites);
        Clover = new Plant("Clover", 10, "A lucky clover.", 15, CloverSprites);
	}

    public Plant getPlant(int PlantNumber)
    {
        Plant PlantToReturn;
        switch (PlantNumber)
        {
            case 0: PlantToReturn = Rose; break;
            case 1: PlantToReturn = Clover; break;
            case 99://random
                int r = 1;
                r = Random.Range(0, 2);
                if (r < 1)
                    PlantToReturn = Rose;
                else PlantToReturn = Clover;
                break;
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
        CurrentSeedHeld = null;
        HeldSeedDisplay.SetActive(false);
        HoldingSeed = false;

        return Sprout;
    }
}
