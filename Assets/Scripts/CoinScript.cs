using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour {

    private int Coins = 10;
    public TextMeshProUGUI CoinsTxt;
    public CoinCollectionScript coinCollectionScript;

	// Use this for initialization
	void Start ()
    {
        CoinsTxt.text = Coins.ToString();
	}
	
	public void gainCoins(int CoinGain)//for pure coin gain with no animation
    {
        Coins += CoinGain;
        CoinsTxt.text = Coins.ToString();
    }

    public void collectCoins(int CoinsCollected, Vector3 FromPosition)//for coin gain with an animation, vector3 should be the position of a plant tile
    {
        coinCollectionScript.playCoinAnimation(CoinsCollected, FromPosition);
        gainCoins(CoinsCollected);
    }

    public int getCurrentCoins()
    {
        return Coins;
    }

    public void spendCoins(int Cost)
    {
        Coins -= Cost;
        CoinsTxt.text = Coins.ToString();
    }
}
