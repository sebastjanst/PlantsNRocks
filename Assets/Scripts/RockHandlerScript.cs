using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;
using UnityEngine.UI;

public class RockHandlerScript : MonoBehaviour {
    //this script defines all the rock types and which sprites to use, it also handles the bonuses the rocks give and handles random rewards of new rocks found in geodes

    //set all the sprites in the unity editor view
    public Sprite RubySprite;
    public Sprite AmethystSprite;
    public Sprite QuartzSprite;
    public Sprite AquamarineSprite;
    public Sprite TigersEyeSprite;

    //the rock class objects that we will create
    private Rock Ruby;
    private Rock Amethyst;
    private Rock Quartz;
    private Rock Aquamarine;
    private Rock TigersEye;

    //assign all the UI texts which display collection numbers from the rock collection panel
    public TextMeshProUGUI RubyTxt;
    public TextMeshProUGUI AmethystTxt;
    public TextMeshProUGUI QuartzTxt;
    public TextMeshProUGUI AquamarineTxt;
    public TextMeshProUGUI TigersEyeTxt;

    //assign the rocks found panel and all the images on it that the panel shows/hides based on what new rocks were found
    public GameObject RocksFoundPanel;
    public GameObject RubyFoundImg;
    public GameObject AmethystFoundImg;
    public GameObject QuartzFoundImg;
    public GameObject AquamarineFoundImg;
    public GameObject TigersEyeFoundImg;

    //assign all the UI texts which display numbers from the rocks found panel
    public TextMeshProUGUI RubyFoundTxt;
    public TextMeshProUGUI AmethystFoundTxt;
    public TextMeshProUGUI QuartzFoundTxt;
    public TextMeshProUGUI AquamarineFoundTxt;
    public TextMeshProUGUI TigersEyeFoundTxt;

    public Rock[] Rocks;//an array that will hold all the rock types (used to pick a random rock)
    private int rockTypesNr;//how many different types there are
    public GameObject GeodeBtn;//the geode button that appears when there are new geodes to open
    private int GeodesFound = 0;//the ammount of new geodes the player can open. if this number is 0, the geode button is hidden

    void Awake()//Awake happens before Start, need this to make sure the class objects exist before any other script tries to access them
    {
        closeRocksFoundPanel();//closes the panel if it was left open in the editor
        GeodeBtn.SetActive(false);//geode button should also start disabled, since there are no geodes found before coins are fed to the tree

        //set up all the rocks and their sprites here
        Ruby = new Rock("Ruby", 0, RubySprite, "Plants grow faster but also lose water faster.");
        Amethyst = new Rock("Amethyst", 0, AmethystSprite,  "Plants grow slightly faster.");
        Quartz = new Rock("Quartz", 0, QuartzSprite, "Find more geodes.");
        Aquamarine = new Rock("Aquamarine", 0, AquamarineSprite, "Plants need less water.");
        TigersEye = new Rock("TigersEye", 0, TigersEyeSprite, "More gold from plants.");

        Rocks = new Rock[]{ Ruby, Amethyst, Quartz, Aquamarine, TigersEye };//stores all the rock objects in an array (used to pick a random rock)
        rockTypesNr = Rocks.Length;
    }

    public void rewardRocks()//rewards new rocks when opening geodes
    {
        RocksFoundPanel.SetActive(true);//show new rocks found in the panel

        //hide all the images unless the rock type was found
        bool RubyFound = false; bool AmethystFound = false; bool QuartzFound = false; bool AquamarineFound = false; bool TigersEyeFound = false;

        //the ammounts of each rock that were found are stored in these
        int RubyFoundAmmount = 0; int AmethystFoundAmmount = 0; int QuartzFoundAmmount = 0; int AquamarineFoundAmmount = 0; int TigersEyeFoundAmmount = 0;

        for (; GeodesFound > 0; GeodesFound--)//loops through every found geode and directly reduces the number of geodes
        {
            int rocksFound = Random.Range(1, 4);//pick a random ammount of rocks for the geode
            for (int i = rocksFound; i > 0; i--)//a loop that assigns a random rock type for each rock found in the geode
            {
                int randomRock = Random.Range(0, rockTypesNr);
                Rocks[randomRock].Ammount++;//already adds the new rock to the number of this rock type in the players collection

                switch (randomRock)//checks and sets which rock needs to be added to the rocks found panel and how many
                {
                    case 0: RubyFound = true; RubyFoundAmmount++; break;
                    case 1: AmethystFound = true; AmethystFoundAmmount++; break;
                    case 2: QuartzFound = true; QuartzFoundAmmount++; break;
                    case 3: AquamarineFound = true; AquamarineFoundAmmount++; break;
                    case 4: TigersEyeFound = true; TigersEyeFoundAmmount++; break;
                    default: break;
                }
            }
        }

        //updates the rocks found graphics for each rock on the rocks found panel
        updateFoundRockImgAndTxts(RubyFoundImg, RubyFoundTxt, RubyFound, RubyFoundAmmount);
        updateFoundRockImgAndTxts(AmethystFoundImg, AmethystFoundTxt, AmethystFound, AmethystFoundAmmount);
        updateFoundRockImgAndTxts(QuartzFoundImg, QuartzFoundTxt, QuartzFound, QuartzFoundAmmount);
        updateFoundRockImgAndTxts(AquamarineFoundImg, AquamarineFoundTxt, AquamarineFound, AquamarineFoundAmmount);
        updateFoundRockImgAndTxts(TigersEyeFoundImg, TigersEyeFoundTxt, TigersEyeFound, TigersEyeFoundAmmount);

        addUnopenedGeodes(0);//0 disables the geode button, as we have opened them all

        updateRockNrTxts();//updates the text numbers on the player's total rock collection panel
    }

    //this function shows or hides the rocks shown on the rocks found panel and updates the number texts
    public void updateFoundRockImgAndTxts(GameObject FoundImg, TextMeshProUGUI FoundTxt, bool FoundStatus, int FoundAmmount)
    {
        //if at least 1 rocks of this type was found the image and text will be enabled
        FoundImg.SetActive(FoundStatus);
        FoundTxt.enabled = FoundStatus;

        FoundTxt.text = FoundAmmount.ToString();//update the text number
    }

    public void updateRockNrTxts()//updates the text numbers on the player's total rock collection panel
    {
        RubyTxt.text = Ruby.Ammount.ToString();
        AmethystTxt.text = Amethyst.Ammount.ToString();
        QuartzTxt.text = Quartz.Ammount.ToString();
        AquamarineTxt.text = Aquamarine.Ammount.ToString();
        TigersEyeTxt.text = TigersEye.Ammount.ToString();
    }

    public void addUnopenedGeodes(int NewGeodes)//other scripts can add new geodes for the player to open using this. 0 disables the geode button
    {
        GeodesFound += NewGeodes;
        if (GeodesFound == 0)
            GeodeBtn.SetActive(false);
        else GeodeBtn.SetActive(true);
    }

    public void closeRocksFoundPanel()
    {
        RocksFoundPanel.SetActive(false);
    }

    //the following "getBonus" functions are used by other scripts to apply bonuses given by collected rocks
    public int getPlantGrowthBonus()
    {
        int GrowthBonus = Ruby.Ammount + (Amethyst.Ammount / 10);//rubies and amethysts both boost growth, but amethysts boost less
        return GrowthBonus;
    }

    public int getWaterDrainBonus()
    {
        int WaterDrainBonus = Ruby.Ammount - (Aquamarine.Ammount/2);//rubies add to water drain, aquamarines reduce water drain
        if (WaterDrainBonus < 0)
            WaterDrainBonus = 0;//make sure water drain is never negative or else water will increase instead
        return WaterDrainBonus;
    }

    public int getCoinRewardBonus()
    {
        int CoinBonus = TigersEye.Ammount;
        return CoinBonus;
    }

    public int getGeodeBonus()
    {
        int GeodeBonus = Quartz.Ammount;
        return GeodeBonus;
    }
}
