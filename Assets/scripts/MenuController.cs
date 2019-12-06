using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Text highScore;
	// Use this for initialization
	void Start () {
       //PlayerPrefs.DeleteAll();
		if (highScore != null) {
			highScore.text = PlayerPrefs.GetInt("HighScore").ToString(); ;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void bt_Play(){
		SceneManager.LoadScene("level_obj", LoadSceneMode.Single);
	}	
	public void bt_Menu(){
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

}
