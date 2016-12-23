using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MatrixMovement{
	
	// Use this for initialization
	protected override void ChildStart ()
	{
		//
	}
	
	// Update is called once per frame
	void Update () {
		Move ();	
	}
	void Move(){
		if(Input.anyKey){
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
			}
			transform.position = currentPosition + offset;
		}
	}
}
