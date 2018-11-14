using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour {

    public GameObject ShopPanel;
    public GameObject TreePanel;

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
}
