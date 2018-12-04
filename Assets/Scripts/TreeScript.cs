using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeScript : MonoBehaviour {

    private bool ButtonLetGo = true;
    public CoinScript coinScript;
    private int TreeCoins;
    public TextMeshProUGUI TreeCoinTxt;
    public TextMeshProUGUI RocksGrownTxt;
    private bool EatingCoins = false;
    private int RockMass = 0;
    public int RocksGrown = 0;

	// Use this for initialization
	void Start ()
    {
        TreeCoins = 0;
        TreeCoinTxt.text = TreeCoins.ToString();
        RocksGrownTxt.text = RocksGrown.ToString();
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
                coinScript.spendCoins(1 + (coinScript.getCurrentCoins() / 10));
                giveCoinsToTree(1 + (coinScript.getCurrentCoins() / 10));
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
            giveCoinsToTree(-1);//negative number takes coins away
            RockMass++;
            if (RockMass >= 10)
                growRock();
        }

        EatingCoins = false;
    }

    private void growRock()
    {
        RockMass-=10;
        RocksGrown++;
        RocksGrownTxt.text = RocksGrown.ToString();
    }

    public void giveCoinsToTree(int GivenCoins)
    {
        TreeCoins += GivenCoins;
        TreeCoinTxt.text = TreeCoins.ToString();
    }
}
