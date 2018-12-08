using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

	public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
