using UnityEngine;
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
		SceneManager.LoadScene("level1", LoadSceneMode.Additive);
	}	
}
