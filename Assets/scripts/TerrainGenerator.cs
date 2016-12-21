using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainGenerator : MonoBehaviour {
	public GameObject grassPrefab;
	public GameObject sandPrefab;
	public GameObject rockPrefab;
	public GameObject boxPrefab;
	public enum TerrainType{Grass, Rock, Box, Sand};
	public TerrainType[,] terrainMatrix;
	public uint terrainLength;
	public uint terrainHeight;

	// Use this for initialization
	void Start () {
		CreateTerrain ();
		DrawTerrain ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CreateTerrain(){
		this.terrainMatrix = new TerrainType[terrainLength,terrainHeight];
		for (int i = 0; i < terrainLength; i++) {
			for (int j = 0; j < terrainHeight; j++) {
				if ((i + j) % 2 == 0) {
					terrainMatrix[i,j] = TerrainType.Rock;
				} else {
					terrainMatrix[i,j] = TerrainType.Sand;
				}
			}
		}
	}
	void DrawTerrain(){
		for (int i = 0; i < terrainLength; i++) {
			for (int j = 0; j < terrainHeight; j++) {
				switch(terrainMatrix[i,j]){
				case TerrainType.Grass:
					grassPrefab.Spawn (new Vector3 (i, j, 0));
					break;
				case TerrainType.Sand:
					sandPrefab.Spawn (new Vector3 (i, j, 0));
					break;
				case TerrainType.Rock:
					rockPrefab.Spawn (new Vector3(i, j, 0));
					break;
				case TerrainType.Box:
					boxPrefab.Spawn (new Vector3 (i, j, 0));
					break;
				}
			}
		}
	}
}
