using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State{escaping, captured, free}
public class GameStatePlayer : MonoBehaviour {
	private State myState;
	private ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		this.myState = State.escaping;	
		scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager> ();
	}

	public State MyState 
	{
		get 
		{ 
			return myState; 
		}
	}
	public void freePlayer(){
		if (MyState == State.escaping) {
			this.myState = State.free;
			scoreManager.setHighScore ();
			SceneManager.LoadScene("youWon", LoadSceneMode.Single);
		}
	}
	public void capturePlayer(){
		if (MyState == State.escaping) {
			this.myState = State.captured;
			SceneManager.LoadScene("youLose", LoadSceneMode.Single);
		}
	}
}
