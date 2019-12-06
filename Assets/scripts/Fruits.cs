using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour {
	public GameObject scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }
    void OnTriggerEnter2D(Collider2D obj){
		if(obj.CompareTag("Fruit")){
			scoreManager.GetComponent<ScoreManager>().AddScore(10);
			gameObject.GetComponent<AudioSource> ().Play ();
            Destroy(obj.gameObject);
        }
	}
}