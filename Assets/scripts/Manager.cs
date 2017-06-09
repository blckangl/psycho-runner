using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public Text highScore;

	// Use this for initialization
	void Start () {
        highScore.text = "High Score :" + (int)PlayerPrefs.GetFloat("HighScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
