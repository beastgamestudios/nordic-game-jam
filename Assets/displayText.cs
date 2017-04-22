using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayText : MonoBehaviour {
//	public GameObject sound;
	public string[] lines;
	public GameObject player;
	private int currentLine;
	private int totalLines;

	// Use this for initialization
	void Start () {
		currentLine = 1;
		totalLines = lines.Length;
		GetComponent<Text>().text = lines[currentLine - 1];
		player.GetComponent<PlayerControl>().control = false;
//		playSound();
	}
	
	// Update is called once per frame
	void Update () {
		player.GetComponent<PlayerControl>().control = false;
		if (Input.GetKeyDown("a")) {

			if (currentLine < totalLines) {
				GetComponent<Text>().text = lines[currentLine];
				currentLine += 1;
			} else {
				currentLine = 1;
				transform.parent.gameObject.SetActive(false);
				player.GetComponent<PlayerControl>().control = true;
			}
		}
	}

	
/* 
	void playSound() {
		if (sound != null) {
			AudioSource[] sounds = sound.GetComponentsInChildren<AudioSource>();
			sounds[Random.Range(0,sounds.Length)].Play();
		}
	}*/
}
