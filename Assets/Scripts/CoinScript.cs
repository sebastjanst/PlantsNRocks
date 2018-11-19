using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour {

    private int Coins;
    public TextMeshProUGUI CoinsTxt;

	// Use this for initialization
	void Start ()
    {
        Coins = 0;
        CoinsTxt.text = Coins.ToString();
	}
	
	public void gainCoins(int CoinGain)
    {
        Coins += CoinGain;
        CoinsTxt.text = Coins.ToString();
    }
}
