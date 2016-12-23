using UnityEngine;
using System.Collections;

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
		if (position.x >= 0f && position.x < terrainGenerator.terrainColumns
			&& position.y >= 0f && position.y < terrainGenerator.terrainRows) {
			if (terrainGenerator.terrainMatrix[(int)position.y,(int)position.x] != TerrainType.Box) {
				return true;
			}
		}

		return false;
	}
	protected abstract void ChildStart ();
}

