using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;

public class SeedDescriptionScript : MonoBehaviour {

    public TextMeshProUGUI ShopCoinTxt;
    public TextMeshProUGUI DescriptionTxt;
    public SeedHandlerScript seedHandlerScript;
    public CoinScript coinScript;
    public UIControler uiControler;
    private Plant currentPlant;

    void Start()
    {
        setCurrentPlant(0);
    }

    void Update()
    {
        ShopCoinTxt.text = coinScript.getCurrentCoins().ToString();
    }

    // Use this for initialization
    void OnEnable ()
    {
        if (currentPlant == null)
            DescriptionTxt.text = "";
        else setDescription();
	}

    public void setCurrentPlant(int PickedSeed)
    {
        currentPlant = seedHandlerScript.getPlant(PickedSeed);
        setDescription();
    }

    public void setDescription()
    {
        DescriptionTxt.text = currentPlant.Description;
    } 

    public void buySeed()
    {
        if (coinScript.getCurrentCoins() >= currentPlant.Price)
        {
            coinScript.spendCoins(currentPlant.buySeed(coinScript.getCurrentCoins()));
            seedHandlerScript.holdSeed(currentPlant);
            uiControler.closeAll();
        }
    }
}
