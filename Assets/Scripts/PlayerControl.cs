﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed;
	private bool DarkRealm; 
	private Image DarkRealmImage;

	// Use this for initialization
	void Start () {
		DarkRealm = false;
		DarkRealmImage = GameObject.Find("Dark Realm").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("down")) {
			transform.position += new Vector3(0, -playerSpeed*Time.deltaTime);
		}
		if (Input.GetKey("up")) {
			transform.position += new Vector3(0, playerSpeed*Time.deltaTime);
		}
		if (Input.GetKey("right")) {
			transform.position += new Vector3(playerSpeed*Time.deltaTime, 0);
		}
		if (Input.GetKey("left")) {
			transform.position += new Vector3(-playerSpeed*Time.deltaTime, 0);
		}
		if (Input.GetKey("tab")) {
			Debug.Log("You are entering the Dark Realm");
			ChangeWorlds();
		}		
	}

void ChangeWorlds() {
	// Code to change back and forth between Reality and Dark Realm
	if (DarkRealm == false) {
		//Enable UI Panel Dark Realm to be true
		DarkRealm = true;
		DarkRealmImage.enabled = true;
	}
	if (DarkRealm == true) {
		// ignore input
		DarkRealm = false;
		DarkRealmImage.enabled = false;
	}
}

}