using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public int scene;
	public int score;
	public Text scoreT;

	// Update is called once per frame
	void Update () {
		scoreT.text = score.ToString ();
	}
    public void AddScore(int s)
    {
        score += s;
    }
	public void setHighScore(){
		int highScore = PlayerPrefs.GetInt ("HighScore");

        PlayerPrefs.SetInt("LatestScore", score);
		Debug.Log ("tentando mudar high score "+highScore);
		if (score > highScore) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}
}
