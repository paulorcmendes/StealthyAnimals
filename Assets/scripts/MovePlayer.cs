﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MatrixMovement{
	protected GameStatePlayer gameStatePlayer;
	// Use this for initialization
	protected override void ChildStart ()
	{
		gameStatePlayer = GetComponent<GameStatePlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();	
	}
    
	protected virtual void Move(){
		if(Input.anyKeyDown && gameStatePlayer.MyState == State.escaping){
            //Debug.Log("Pressed key");
			Vector2 translation = Vector2.zero;
			if (Input.GetKeyDown("a")) {
				translation = new Vector2 (-1.0f, 0.0f);
			} else if (Input.GetKeyDown("d")) {
				translation = new Vector2 (1.0f, 0.0f);
			} else if(Input.GetKeyDown("s")){
				translation = new Vector2 (0.0f,-1.0f);
			} else if (Input.GetKeyDown("w")){
				translation = new Vector2 (0.0f,1.0f);    	
			}		
			if (CanMove (currentPosition + translation)) {
				currentPosition += translation; 
				//haveIWon (currentPosition);
			}
			transform.position = currentPosition + offset;
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Guard")) {
			Debug.Log ("cap");
			gameStatePlayer.capturePlayer ();
		}
        if (coll.gameObject.CompareTag("Exit"))
        {
            gameStatePlayer.freePlayer();
            Debug.Log("win");
        }
    }
	protected void haveIWon(Vector2 position){
		if (terrainGenerator.terrainMatrix [(int)position.y, (int)position.x] == TerrainType.Exit) {
			gameStatePlayer.freePlayer ();
			Debug.Log("win");
		}
	}
}
