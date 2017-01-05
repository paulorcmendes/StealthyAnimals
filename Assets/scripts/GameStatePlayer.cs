using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{escaping, captured, free}
public class GameStatePlayer : MonoBehaviour {
	private State myState;
	// Use this for initialization
	void Start () {
		this.myState = State.escaping;	
	}

	public State MyState 
	{
		get 
		{ 
			return myState; 
		}
	}
	public void freePlayer(){
		if (MyState == State.escaping)
			this.myState = State.free;
	}
	public void capturePlayer(){
		if (MyState == State.escaping)
			this.myState = State.captured;
	}
}
