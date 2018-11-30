using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectionScript : MonoBehaviour {

    public GameObject CoinTxtObject;
    public TextMeshProUGUI CoinTxt;
    private Transform tr;
    public Transform CoinsTr;

	// Use this for initialization
	void Start ()
    {
        tr = this.gameObject.GetComponent<Transform>();
        CoinTxtObject.SetActive(false);
    }
	
    public void playCoinAnimation(int Coins, Vector3 FromPosition)
    {
        CoinTxtObject.SetActive(true);
        tr.position = FromPosition;
        CoinTxt.text = Coins.ToString();
        StartCoroutine(coinFloatAnimation());
    }

    IEnumerator coinFloatAnimation()
    {
        while (tr.position != CoinsTr.position)
        {
            yield return new WaitForEndOfFrame();
            tr.position = Vector3.MoveTowards(tr.position, CoinsTr.position, 0.15f);
        }
        CoinTxtObject.SetActive(false);
    }
}
