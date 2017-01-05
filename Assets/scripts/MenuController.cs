﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Text highScore;
	// Use this for initialization
	void Start () {
		highScore.text = PlayerPrefs.GetInt ("highScore").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void bt_Play(){
		SceneManager.LoadScene("Menu_levels", LoadSceneMode.Additive);
	}	

	public void bt_1(){
		SceneManager.LoadScene("level1", LoadSceneMode.Additive);
	}	
	public void bt_2(){
		SceneManager.LoadScene("level2", LoadSceneMode.Additive);
	}
	public void bt_3(){
		SceneManager.LoadScene("level3", LoadSceneMode.Additive);
	}
	public void bt_4(){
		SceneManager.LoadScene("level4", LoadSceneMode.Additive);
	}
	public void bt_5(){
		SceneManager.LoadScene("level5", LoadSceneMode.Additive);
	}
	public void bt_6(){
		SceneManager.LoadScene("level6", LoadSceneMode.Additive);
	}
	public void bt_7(){
		SceneManager.LoadScene("level7", LoadSceneMode.Additive);
	}			
	public void bt_8(){
		SceneManager.LoadScene("level8", LoadSceneMode.Additive);
	}		
	public void bt_9(){
		SceneManager.LoadScene("level9", LoadSceneMode.Additive);
	}
	public void bt_10(){
		SceneManager.LoadScene("level10", LoadSceneMode.Additive);
	}		
}
