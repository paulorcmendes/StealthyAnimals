using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 0 - Grass
 * 1 - Sand
 * 2 - Rock
 * 3 - Sand
 */
public enum TerrainType{Grass, Sand, Rock, Box};
public class TerrainGenerator : MonoBehaviour {
	public GameObject grassPrefab;
	public GameObject sandPrefab;
	public GameObject rockPrefab;
	public GameObject boxPrefab;

	public TerrainType[,] terrainMatrix;
	public uint terrainColumns;
	public uint terrainRows;
	public GameObject player;

	// Use this for initialization
	void Start () {
		CreateTerrain ();
		DrawTerrain ();
		player.Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CreateTerrain(){
		int indexTxtMap = 0;
		terrainMatrix = new TerrainType[terrainRows, terrainColumns];
		string[] txtMap = GetComponent<ReadLevel> ().ReadMap ();
		for (int i = 0; i < terrainRows; i++) {
			for (int j = 0; j < terrainColumns; j++) {
				switch (txtMap [indexTxtMap++]) {
				case "0":
					terrainMatrix [(terrainRows-1)-i, j] = TerrainType.Grass;
					break;
				case "1":
					terrainMatrix [(terrainRows-1)-i, j] = TerrainType.Sand;
					break;
				case "2":
					terrainMatrix [(terrainRows-1)-i, j] = TerrainType.Rock;
					break;
				case "3":
					terrainMatrix [(terrainRows-1)-i, j] = TerrainType.Box;
					break;
				}
			}
		}
	}
	void DrawTerrain(){
		//x é coluna - j
		//y é linha - i
		for (int i = 0; i < terrainRows; i++) {
			for (int j = 0; j < terrainColumns; j++) {
				switch(terrainMatrix[i,j]){
				case TerrainType.Grass:
					grassPrefab.Spawn (new Vector3 (j, i, 1));
					break;
				case TerrainType.Sand:
					sandPrefab.Spawn (new Vector3 (j, i, 1));
					break;
				case TerrainType.Rock:
					rockPrefab.Spawn (new Vector3(j, i, 1));
					break;
				case TerrainType.Box:
					boxPrefab.Spawn (new Vector3 (j, i, 1));
					break;
				}
			}
		}
	}
}
