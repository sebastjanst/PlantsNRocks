using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour {
    //this script handles opening and closing all of the game's other panels

    public GameObject ShopPanel;
    public GameObject TreePanel;
    public GameObject RockPanel;

	// Use this for initialization
	void Start ()
    {
        closeAll();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeAll();
        }
    }

    public void closeAll()
    {
        ShopPanel.SetActive(false);
        TreePanel.SetActive(false);
        RockPanel.SetActive(false);
    }

    public void toggleShopPanel()
    {
        if(ShopPanel.activeSelf)
            ShopPanel.SetActive(false);
        else ShopPanel.SetActive(true);
    }

    public void toggleTreePanel()
    {
        if (TreePanel.activeSelf)
            TreePanel.SetActive(false);
        else TreePanel.SetActive(true);
    }

    public void toggleRockPanel()
    {
        if (RockPanel.activeSelf)
            RockPanel.SetActive(false);
        else RockPanel.SetActive(true);
    }
}
