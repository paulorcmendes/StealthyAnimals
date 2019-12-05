using UnityEngine;
using System.Collections;
using System;

public abstract class MatrixMovement : MonoBehaviour
{
	public Vector2 offset;
	public Vector2 currentPosition;
	protected TerrainGenerator terrainGenerator;
	// Use this for initialization
	void Start ()
	{
		terrainGenerator = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TerrainGenerator> (); 
		transform.position = currentPosition + offset;
		ChildStart ();
	}

	protected bool CanMove(Vector2 position){
		//Debug.Log ("Moveu" + position.x +" "+ position.y);
		if (position.x >= offset.x && position.x < terrainGenerator.terrainColumns-offset.x
			&& position.y >= offset.y && position.y < terrainGenerator.terrainRows-offset.y) {
			//if (terrainGenerator.terrainMatrix[(int) position.y,(int)position.x] != TerrainType.Box) {
				return true;
			//}
		}

		return false;
	}
	protected abstract void ChildStart ();
}

