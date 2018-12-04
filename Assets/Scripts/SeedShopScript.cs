using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;

public class SeedShopScript : MonoBehaviour {

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
            if (seedHandlerScript.seedCheck())//if holding a seed that hasn't been planted, refund it
            {
                coinScript.gainCoins(seedHandlerScript.whatSeedIsHeld().Price);
            }

            coinScript.spendCoins(currentPlant.buySeed(coinScript.getCurrentCoins()));
            seedHandlerScript.holdSeed(currentPlant);
            uiControler.closeAll();
        }
    }
}
