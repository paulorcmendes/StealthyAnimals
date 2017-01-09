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
	public void setHighScore(){
		int highScore = PlayerPrefs.GetInt ("Score"+scene);
		Debug.Log ("tentando mudar high score "+highScore);
		if (score > highScore) {
			PlayerPrefs.SetInt ("Score"+scene, score);
		}
	}
}
