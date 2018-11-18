using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

[System.Serializable]
public class SeedHandlerScript : MonoBehaviour {

    public GrowthScript growthScript;

    private Plant Rose;
    public Sprite[] RoseSprites = new Sprite[5];

    private Plant Clover;
    public Sprite[] CloverSprites = new Sprite[5];

    // Use this for initialization
    void Awake ()
    {
        Rose = new Plant("Rose", 0, RoseSprites);
        Clover = new Plant("Clover", 10, CloverSprites);
	}

    public Plant getPlant()
    {
        int r = 1;
        r = Random.Range(0, 2);
        if (r < 1)
            return Rose;
        else return Clover;
    }
}
