using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectionScript : MonoBehaviour {

    public GameObject CoinTxtObject;//the gameobject of the collected coins (used to hide/unhide the text and image)
    public TextMeshProUGUI CoinTxt;//the text that shows the number of collected coins
    private Transform tr;
    public Transform CoinsTr; //the location where the collected coins number will fly to (in this case the tr should be the upper right corner of the screen)

	// Use this for initialization
	void Start ()
    {
        tr = this.gameObject.GetComponent<Transform>();
        CoinTxtObject.SetActive(false);//the collected coins graphic remains hidden untill coins are collected
    }
	
    public void playCoinAnimation(int Coins, Vector3 FromPosition)//sets everything up for the coin collection animation
    {
        CoinTxtObject.SetActive(true);//enables the image and text
        tr.position = FromPosition;//start position as specified when the function is called
        CoinTxt.text = Coins.ToString();//the ammount of new coins collected is added to the text
        StartCoroutine(coinFloatAnimation());//starts the actual animation that floats the collected coins up into the total coins
    }

    IEnumerator coinFloatAnimation()//handles the movement of the graphic from the harvested plant to the coin number in the top right of the screen where the CoinsTr is placed
    {
        while (tr.position != CoinsTr.position)
        {
            yield return new WaitForEndOfFrame();//animation progresses every frame
            tr.position = Vector3.MoveTowards(tr.position, CoinsTr.position, 0.15f);//moves the graphic toward the target position
            //MoveTowards never overshoots the target, so this should always hit the target and end the "while" loop
        }
        CoinTxtObject.SetActive(false);//once the destination is reached the graphic is disabled again
    }
}
