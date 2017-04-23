using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
	private GameObject player;
	[HideInInspector]public string sceneName;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == player) {
			SceneManager.LoadScene(sceneName);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
