using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;

public class SeedShopScript : MonoBehaviour {

    public TextMeshProUGUI ShopCoinTxt;//the coins the player has, displayed at the top of the shop panel
    public TextMeshProUGUI DescriptionTxt;//not used
    public SeedHandlerScript seedHandlerScript;
    public CoinScript coinScript;
    public UIControler uiControler;
    private Plant currentPlant;

    void Start()
    {
        setCurrentPlant(0);//starts game with the rose seed held and ready to plant
    }

    void Update()
    {
        ShopCoinTxt.text = coinScript.getCurrentCoins().ToString();//updates the coins the player has that are displayed on the shop panel
    }

    void OnEnable ()
    {
        //not used
        if (currentPlant == null)
            DescriptionTxt.text = "";
        else setDescription();
	}

    public void setCurrentPlant(int PickedSeed)//function used by the button scripts on the seed panel plant images, the picked seed number decides which plant it buys
    {
        currentPlant = seedHandlerScript.getPlant(PickedSeed);
        setDescription();
    }

    public void setDescription()//not used
    {
        DescriptionTxt.text = currentPlant.Description;
    } 

    public void buySeed()//the function that handles buying a seed
    {
        if (coinScript.getCurrentCoins() >= currentPlant.Price)//if the player has enough coins to buy a new seed
        {
            if (seedHandlerScript.seedCheck())//if already holding a seed that hasn't been planted, refund it
            {
                coinScript.gainCoins(seedHandlerScript.whatSeedIsHeld().Price);//find how much coins to refund and give it back to the player
            }

            coinScript.spendCoins(currentPlant.getPrice());//spends coins to buy new seed
            seedHandlerScript.holdSeed(currentPlant);//puts new seed in hand
            uiControler.closeAll();//closes all panels so the player can plant the new seed
        }
    }
}
