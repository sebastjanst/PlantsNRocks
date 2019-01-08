using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TreeScript : MonoBehaviour {
    //this script handles giving the tree coins and everything connected to the tree

    private bool ButtonLetGo = true;
    public CoinScript coinScript;
    private int TreeCoins;
    public TextMeshProUGUI TreeCoinTxt;//the number text on the tree's top
    private bool EatingCoins = false;
    private int RockMass = 0;
    private int NextGeode = 10;
    public int GeodesGrown = 0;//how many geodes have been found in total, not used for anything right now
    public RockHandlerScript rockHandlerScript;

    private float TotalCoinsFed = 0;//the total number of coins donated to the tree
    private float TotalCoinFedGoal = 10000000;//the number of coins that need to be donated to win the game
    public Image CoinBarImg;//the coins donated bar under the coin number text
    public GameObject EndingPanel;//the end screen when you beat the game

    // Use this for initialization
    void Start ()
    {
        TreeCoins = 0;
        TreeCoinTxt.text = TreeCoins.ToString();
        CoinBarImg.fillAmount = 0;
        EndingPanel.SetActive(false);
    }

    private void Update()
    {
        if (EatingCoins == false && TreeCoins > 0)//if there are uneaten donated coins in the tree, it starts eating them
        {
            StartCoroutine(eatCoins());
        }
    }

    public void buttonHeld(bool BtnHeld)//if the tree top is clicked and held down it drains coins over time
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

    IEnumerator drainCoins()//drains the player's coins into the tree as the button is held down
    {
        while (ButtonLetGo == false)
        {
            if (coinScript.getCurrentCoins() > 0)//while the player still has some coins
            {
                int CoinsToDrain = 1 + (coinScript.getCurrentCoins() / 10);//drains coins faster for every 10 coins the player has
                coinScript.spendCoins(CoinsToDrain);//takes the coins away from the player
                updateCoinBar(CoinsToDrain);//added coins add to coin goal and update coin bar
                giveCoinsToTree(CoinsToDrain);//added coins are given to the tree
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator eatCoins()//the tree eats any coins still remaining in it's treetop
    {
        EatingCoins = true;

        while (TreeCoins > 0)//while it still has coins to eat
        {
            yield return new WaitForSeconds(2f);
            int CoinsToEat = 1 + (TreeCoins / 10);//eats coins faster the more there are
            giveCoinsToTree(-CoinsToEat);//negative number, since in this case it takes coins away, coins get eaten faster for every 10 coins

            RockMass += CoinsToEat;//eaten coins get added to the rockmass, which creates new geodes
            if (RockMass >= NextGeode)//if the rockmass is big enough to make a new geode
                growRock();//grows a geode
        }

        EatingCoins = false;
    }

    private void growRock()//grows geodes
    {
        int RocksToGrow = 0;
        int GeodeBonus = rockHandlerScript.getGeodeBonus();//bonus to found geodes from quartz
        if (GeodeBonus >= NextGeode / 2)//limit geode bonus so it doesn't ever reduce the next geode number
            GeodeBonus = (NextGeode / 2) - 1;

        while (RockMass >= NextGeode)//loops through the rock mass to see how many new geodes can be made from it
        {
            RocksToGrow++;//add one geode
            RockMass -= NextGeode;//reduce rock mass for each geode grown
            NextGeode += (NextGeode/2) - GeodeBonus;//each next geode takes more rock mass to grow
            GeodesGrown += 1;//adds total geodes grown number, not used for anything right now
        }

        rockHandlerScript.addUnopenedGeodes(RocksToGrow);//store new unopened geodes in the rock script
    }

    public void giveCoinsToTree(int GivenCoins)//handles the number of coins in the treetop
    {
        TreeCoins += GivenCoins;
        TreeCoinTxt.text = TreeCoins.ToString();//updats the number text in the tree top
    }

    public void updateCoinBar(int NewCoins)//handles the coin donation bar on the tree top and the game ending
    {
        TotalCoinsFed += NewCoins;
        CoinBarImg.fillAmount = TotalCoinsFed / TotalCoinFedGoal;

        if (TotalCoinsFed >= TotalCoinFedGoal)//if the coin donation goal is reached
            EndingPanel.SetActive(true);//game ending
    }
}
