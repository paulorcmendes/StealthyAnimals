using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Text highScore1,highScore2,highScore3,highScore4,highScore5,
	highScore6,highScore7,highScore8,highScore9,highScore10,highScore;
	private int addHighScores;
	// Use this for initialization
	void Start () {
		addHighScores = 0;
		/*if (highScore != null) {
			highScore.text = PlayerPrefs.GetInt ("Score1").ToString ();
		}*/
		if (highScore1 != null) {
			highScore1.text = PlayerPrefs.GetInt ("Score1").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score1");
		}
		if (highScore2 != null) {
			highScore2.text = PlayerPrefs.GetInt ("Score2").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score2");
		}
		if (highScore3 != null) {
			highScore3.text = PlayerPrefs.GetInt ("Score3").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score3");
		}
		if (highScore4 != null) {
			highScore4.text = PlayerPrefs.GetInt ("Score4").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score4");
			
		}
		if (highScore5 != null) {
			highScore5.text = PlayerPrefs.GetInt ("Score5").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score5");
		}
		if (highScore6 != null) {
			highScore6.text = PlayerPrefs.GetInt ("Score6").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score6");
		}
		if (highScore7 != null) {
			highScore7.text = PlayerPrefs.GetInt ("Score7").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score7");
		}
		if (highScore8 != null) {
			highScore8.text = PlayerPrefs.GetInt ("Score8").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score8");
		}
		if (highScore9 != null) {
			highScore9.text = PlayerPrefs.GetInt ("Score9").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score9");
		}
		if (highScore10 != null) {
			highScore10.text = PlayerPrefs.GetInt ("Score10").ToString ();
			addHighScores += PlayerPrefs.GetInt ("Score10");
		}
		if (highScore != null) {
			highScore.text = addHighScores.ToString ();	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void bt_Play(){
		SceneManager.LoadScene("Menu_levels", LoadSceneMode.Single);
	}	

	public void bt_1(){
		SceneManager.LoadScene("level1", LoadSceneMode.Single);
	}	
	public void bt_2(){
		SceneManager.LoadScene("level2", LoadSceneMode.Single);
	}
	public void bt_3(){
		SceneManager.LoadScene("level3", LoadSceneMode.Single);
	}
	public void bt_4(){
		SceneManager.LoadScene("level4", LoadSceneMode.Single);
	}
	public void bt_5(){
		SceneManager.LoadScene("level5", LoadSceneMode.Single);
	}
	public void bt_6(){
		SceneManager.LoadScene("level6", LoadSceneMode.Single);
	}
	public void bt_7(){
		SceneManager.LoadScene("level7", LoadSceneMode.Single);
	}			
	public void bt_8(){
		SceneManager.LoadScene("level8", LoadSceneMode.Single);
	}		
	public void bt_9(){
		SceneManager.LoadScene("level9", LoadSceneMode.Single);
	}
	public void bt_10(){
		SceneManager.LoadScene("level10", LoadSceneMode.Single);
	}		
}
