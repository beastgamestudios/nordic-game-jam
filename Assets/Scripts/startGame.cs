using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Start")) {
			dontDestroy bgMusic = (dontDestroy)FindObjectOfType(typeof(dontDestroy));
			if (bgMusic != null) {
				Destroy(bgMusic.gameObject);
			}
			SceneManager.LoadScene("title");
		}
	}
}
