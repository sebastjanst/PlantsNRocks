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
    public Image RubyFoundImg;
    public Image AmethystFoundImg;
    public Image QuartzFoundImg;
    public Image AquamarineFoundImg;
    public Image TigersEyeFoundImg;

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
        Amethyst = new Rock("Amethyst", 0, AmethystSprite,  "");
        Quartz = new Rock("Quartz", 0, QuartzSprite, "");
        Aquamarine = new Rock("Aquamarine", 0, AquamarineSprite, "");
        TigersEye = new Rock("TigersEye", 0, TigersEyeSprite, "");

        Rocks = new Rock[]{ Ruby, Amethyst, Quartz, Aquamarine, TigersEye };
        rockTypesNr = Rocks.Length;
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
        int RubiesFound = 0; int AmethystsFound = 0; int QuartzsFound = 0; int AquamarinesFound = 0; int TigersEyesFound = 0;

        for (; GeodesFound > 0; GeodesFound--)
        {
            int rocksFound = Random.Range(1, 4);
            for (int i = rocksFound; i > 0; i--)
            {
                int randomRock = Random.Range(0, rockTypesNr);
                Rocks[randomRock].Ammount++;

                switch (randomRock)
                {
                    case 0: RubyFound = true; RubiesFound++; break;
                    case 1: AmethystFound = true; AmethystsFound++; break;
                    case 2: QuartzFound = true; QuartzsFound++; break;
                    case 3: AquamarineFound = true; AquamarinesFound++; break;
                    case 4: TigersEyeFound = true; TigersEyesFound++; break;
                    default: break;
                }
            }
        }

        RubyFoundImg.enabled = RubyFound; RubyFoundTxt.enabled = RubyFound; RubyFoundTxt.text = RubiesFound.ToString();
        AmethystFoundImg.enabled = AmethystFound; AmethystFoundTxt.enabled = AmethystFound; AmethystFoundTxt.text = AmethystsFound.ToString();
        QuartzFoundImg.enabled = QuartzFound; QuartzFoundTxt.enabled = QuartzFound; QuartzFoundTxt.text = QuartzsFound.ToString();
        AquamarineFoundImg.enabled = AquamarineFound; AquamarineFoundTxt.enabled = AquamarineFound; AquamarineFoundTxt.text = AquamarinesFound.ToString();
        TigersEyeFoundImg.enabled = TigersEyeFound; TigersEyeFoundTxt.enabled = TigersEyeFound; TigersEyeFoundTxt.text = TigersEyesFound.ToString();

        addUnopenedGeodes(0);

        updateRockNrTxts();
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
