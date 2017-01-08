using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public int score;
	public Text scoreT;

	// Update is called once per frame
	void Update () {
		scoreT.text = score.ToString ();
	}
}
