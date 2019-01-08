using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour {

    private int Coins = 10;//set starting coins here
    public TextMeshProUGUI CoinsTxt;//the text at the top of the screen that shows the players current coin total
    public CoinCollectionScript coinCollectionScript;//the script that handles and animates new coins collected from plants

	// Use this for initialization
	void Start ()
    {
        CoinsTxt.text = Coins.ToString();//updates the coin text with our starting number of coins
	}
	
	public void gainCoins(int CoinGain)//for pure coin gain with no animation
    {
        Coins += CoinGain;
        CoinsTxt.text = Coins.ToString();//always remember to update the text
    }

    public void collectCoins(int CoinsCollected, Vector3 FromPosition)//for coin gain with an animation, "FromPosition" should be the position of a plant tile
    {
        coinCollectionScript.playCoinAnimation(CoinsCollected, FromPosition);//play animation
        gainCoins(CoinsCollected);//adds the new coins
    }

    public int getCurrentCoins()//for other scripts that need to know how many coins the player has (e.g. the shop)
    {
        return Coins;
    }

    public void spendCoins(int Cost)//the same as gainCoins but subtracts coins instead. Used by shop
        //Might be redundant to have both, but it's easier to understand "gain/spend"
    {
        Coins -= Cost;
        CoinsTxt.text = Coins.ToString();
    }
}
