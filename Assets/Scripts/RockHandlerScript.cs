using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;
using UnityEngine.UI;

public class RockHandlerScript : MonoBehaviour {

    public Sprite RubySprite;
    public Sprite AmethystSprite;
    public Sprite QuartzSprite;
    public Sprite AquamarineSprite;
    public Sprite TigersEyeSprite;

    private Rock Ruby;
    private Rock Amethyst;
    private Rock Quartz;
    private Rock Aquamarine;
    private Rock TigersEye;

    public TextMeshProUGUI RubyTxt;
    public TextMeshProUGUI AmethystTxt;
    public TextMeshProUGUI QuartzTxt;
    public TextMeshProUGUI AquamarineTxt;
    public TextMeshProUGUI TigersEyeTxt;

    public GameObject RocksFoundPanel;
    public GameObject RubyFoundImg;
    public GameObject AmethystFoundImg;
    public GameObject QuartzFoundImg;
    public GameObject AquamarineFoundImg;
    public GameObject TigersEyeFoundImg;

    public TextMeshProUGUI RubyFoundTxt;
    public TextMeshProUGUI AmethystFoundTxt;
    public TextMeshProUGUI QuartzFoundTxt;
    public TextMeshProUGUI AquamarineFoundTxt;
    public TextMeshProUGUI TigersEyeFoundTxt;

    public Rock[] Rocks;
    private int rockTypesNr;
    public GameObject GeodeBtn;
    private int GeodesFound = 0;

    void Awake()//Awake happens before Start
    {
        closeRocksFoundPanel();
        Ruby = new Rock("Ruby", 0, RubySprite, "Plants grow faster but also lose water faster.");
        Amethyst = new Rock("Amethyst", 0, AmethystSprite,  "Plants grow slightly faster.");
        Quartz = new Rock("Quartz", 0, QuartzSprite, "Find more geodes.");
        Aquamarine = new Rock("Aquamarine", 0, AquamarineSprite, "Plants need less water.");
        TigersEye = new Rock("TigersEye", 0, TigersEyeSprite, "More gold from plants.");

        Rocks = new Rock[]{ Ruby, Amethyst, Quartz, Aquamarine, TigersEye };
        rockTypesNr = Rocks.Length;
    }

    public int getPlantGrowthBonus()
    {
        int GrowthBonus = Ruby.Ammount + (Amethyst.Ammount / 10);
        return GrowthBonus;
    }

    public int getWaterDrainBonus()
    {
        int WaterDrainBonus = Ruby.Ammount - (Aquamarine.Ammount/2);
        if (WaterDrainBonus < 0)
            WaterDrainBonus = 0;
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

    public void addUnopenedGeodes(int NewGeodes)
    {
        GeodesFound += NewGeodes;
        if(GeodesFound == 0)
            GeodeBtn.SetActive(false);
        else GeodeBtn.SetActive(true);
    }

    public void closeRocksFoundPanel()
    {
        RocksFoundPanel.SetActive(false);
        GeodeBtn.SetActive(false);
    }

    public void rewardRocks()
    {
        RocksFoundPanel.SetActive(true);

        bool RubyFound = false; bool AmethystFound = false; bool QuartzFound = false; bool AquamarineFound = false; bool TigersEyeFound = false;
        int RubyFoundAmmount = 0; int AmethystFoundAmmount = 0; int QuartzFoundAmmount = 0; int AquamarineFoundAmmount = 0; int TigersEyeFoundAmmount = 0;

        for (; GeodesFound > 0; GeodesFound--)
        {
            int rocksFound = Random.Range(1, 4);
            for (int i = rocksFound; i > 0; i--)
            {
                int randomRock = Random.Range(0, rockTypesNr);
                Rocks[randomRock].Ammount++;

                switch (randomRock)
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

        updateFoundRockImgAndTxts(RubyFoundImg, RubyFoundTxt, RubyFound, RubyFoundAmmount);
        updateFoundRockImgAndTxts(AmethystFoundImg, AmethystFoundTxt, AmethystFound, AmethystFoundAmmount);
        updateFoundRockImgAndTxts(QuartzFoundImg, QuartzFoundTxt, QuartzFound, QuartzFoundAmmount);
        updateFoundRockImgAndTxts(AquamarineFoundImg, AquamarineFoundTxt, AquamarineFound, AquamarineFoundAmmount);
        updateFoundRockImgAndTxts(TigersEyeFoundImg, TigersEyeFoundTxt, TigersEyeFound, TigersEyeFoundAmmount);

        addUnopenedGeodes(0);

        updateRockNrTxts();
    }

    public void updateFoundRockImgAndTxts(GameObject FoundImg, TextMeshProUGUI FoundTxt, bool FoundStatus, int FoundAmmount)
    {
        FoundImg.SetActive(FoundStatus);
        FoundTxt.enabled = FoundStatus;
        FoundTxt.text = FoundAmmount.ToString();
    }

    public void updateRockNrTxts()
    {
        RubyTxt.text = Ruby.Ammount.ToString();
        AmethystTxt.text = Amethyst.Ammount.ToString();
        QuartzTxt.text = Quartz.Ammount.ToString();
        AquamarineTxt.text = Aquamarine.Ammount.ToString();
        TigersEyeTxt.text = TigersEye.Ammount.ToString();
    }
}
