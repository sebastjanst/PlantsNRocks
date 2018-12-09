﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeScript : MonoBehaviour {

    private bool ButtonLetGo = true;
    public CoinScript coinScript;
    private int TreeCoins;
    public TextMeshProUGUI TreeCoinTxt;
    private bool EatingCoins = false;
    private int RockMass = 0;
    public int RocksGrown = 0;
    public RockHandlerScript rockHandlerScript;

	// Use this for initialization
	void Start ()
    {
        TreeCoins = 0;
        TreeCoinTxt.text = TreeCoins.ToString();
    }

    private void Update()
    {
        if (EatingCoins == false && TreeCoins > 0)
        {
            StartCoroutine(eatCoins());
        }
    }

    public void buttonHeld(bool BtnHeld)
    {
        if (BtnHeld)
        {
            ButtonLetGo = false;
            StartCoroutine(drainCoins());
        }
        else
        {
            ButtonLetGo = true;
        }
    }

    IEnumerator drainCoins()
    {
        while (ButtonLetGo == false)
        {
            if (coinScript.getCurrentCoins() > 0)
            {
                int CoinsToDrain = 1 + (coinScript.getCurrentCoins() / 10);
                coinScript.spendCoins(CoinsToDrain);
                giveCoinsToTree(CoinsToDrain);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator eatCoins()
    {
        EatingCoins = true;

        while (TreeCoins > 0)
        {
            yield return new WaitForSeconds(2f);
            int CoinsToEat = 1 + (TreeCoins / 10);
            giveCoinsToTree(-CoinsToEat);//negative number takes coins away, coins get eaten faster for every 10 coins
            RockMass += CoinsToEat;
            if (RockMass >= 10)
                growRock();
        }

        EatingCoins = false;
    }

    private void growRock()
    {
        int RocksToGrow = RockMass / 10;//for each 10 RockMass 1 rock will be grown
        RockMass -= RocksToGrow * 10;//spends 10 rockmass for each rock grown
        RocksGrown += RocksToGrow;

        rockHandlerScript.addUnopenedGeodes(RocksToGrow);
    }

    public void giveCoinsToTree(int GivenCoins)
    {
        TreeCoins += GivenCoins;
        TreeCoinTxt.text = TreeCoins.ToString();
    }
}
