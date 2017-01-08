﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour {
	public GameObject scoreManager;
	void OnTriggerEnter2D(Collider2D obj){
		if(obj.CompareTag("Player")){
			scoreManager.GetComponent<ScoreManager>().score+=10;
		}
	}

	void OnTriggerExit2D(Collider2D obj){
		if(obj.CompareTag("Player")){
			Destroy(gameObject);
		}
	}
}