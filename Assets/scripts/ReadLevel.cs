using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLevel : MonoBehaviour {
	public string txtFile;
	// Use this for initialization
	void Start () {
		string[] map = System.IO.File.ReadAllText (txtFile).Split (',');
		//System.IO.File.WriteAllText ("teste.txt", "pedro eh bundao");
		Debug.Log (map[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
