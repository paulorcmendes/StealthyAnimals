using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadLevel : MonoBehaviour {
	public string txtFile;

	public string[] ReadMap(){
		string txt = Regex.Replace (System.IO.File.ReadAllText (txtFile), @"\s+", string.Empty);
		return txt.Split (',');
	}
}
