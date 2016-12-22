using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	private TerrainType[,] terrainMatrix;
	public Vector2 offset;
	public Vector2 currentPosition;
	private uint terrainColumns;
	private uint terrainRows;

	// Use this for initialization
	void Start () {
		TerrainGenerator terrainGenerator = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TerrainGenerator> (); 
		terrainMatrix = terrainGenerator.terrainMatrix;
		terrainColumns = terrainGenerator.terrainColumns;
		terrainRows = terrainGenerator.terrainRows;
		transform.position = currentPosition + offset;
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

	bool CanMove(Vector2 position){
		Debug.Log ("Moveu" + position.x +" "+ position.y);
		if (position.x >= 0f && position.x < terrainColumns
			&& position.y >= 0f && position.y < terrainRows) {
			if (terrainMatrix[(int)position.y,(int)position.x] != TerrainType.Box) {
				return true;
			}
		}

		return false;
	}
}
