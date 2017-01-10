using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LatestScore : MonoBehaviour
{
	public Text score;
	// Use this for initialization
	void Start ()
	{
		int lastScore = PlayerPrefs.GetInt ("LatestScore");
		score.text = (""+lastScore);
	}
	

}

