using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;

public class RockHandlerScript : MonoBehaviour {

    private Rock Ruby = new Rock("Ruby", 0, "Plants grow faster but also lose water faster.");
    private Rock Amethyst = new Rock("Amethyst", 0, "");
    private Rock Quartz = new Rock("Quartz", 0, "");
    private Rock Aquamarine = new Rock("Aquamarine", 0, "");
    private Rock TigersEye = new Rock("TigersEye", 0, "");

    public TextMeshProUGUI RubyTxt;
    public TextMeshProUGUI AmethystTxt;
    public TextMeshProUGUI QuartzTxt;
    public TextMeshProUGUI AquamarineTxt;
    public TextMeshProUGUI TigersEyeTxt;

    public Rock[] Rocks;
    private int rockTypesNr;

    void Start()
    {
        Rocks = new Rock[]{ Ruby, Amethyst, Quartz, Aquamarine, TigersEye };
        rockTypesNr = Rocks.Length;
    }

    public void rewardRocks(int GeodesFound)
    {
        for (; GeodesFound > 0; GeodesFound--)
        {
            int rocksFound = Random.Range(1, 4);
            for (int i = rocksFound; i > 0; i--)
            {
                int randomRock = Random.Range(0, rockTypesNr);
                Rocks[randomRock].Ammount++;
            }
        }
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
