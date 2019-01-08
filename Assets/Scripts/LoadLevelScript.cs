using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {
    //this script is used by the button on the intro scene to load the main game scene
	public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
