using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed;
	private Animator playerAnimator;
	private bool DarkRealm; 
	private Image DarkRealmImage;

	// Use this for initialization
	void Start () {
		DarkRealm = false;
		// DarkRealmImage = GameObject.Find("Dark Realm").GetComponent<Image>();
		playerAnimator = GetComponent<Animator>();
		playerAnimator.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("down")) {
			transform.position += new Vector3(0, -playerSpeed*Time.deltaTime);
			playerAnimator.Play("walkDown");
		}
	    if (Input.GetKeyUp("down")) {
			playerAnimator.Play("Idle");
		}
	    if (Input.GetKeyUp("up")) {
			playerAnimator.Play("IdleDown");
		}
	    if (Input.GetKeyUp("right")) {
			playerAnimator.Play("IdleRight");
		}
	    if (Input.GetKeyUp("left")) {
			playerAnimator.Play("IdleLeft");
		}		

		if (Input.GetKey("up")) {
			transform.position += new Vector3(0, playerSpeed*Time.deltaTime);
			playerAnimator.Play("walkUp");
		}

		if (Input.GetKey("right")) {
			transform.position += new Vector3(playerSpeed*Time.deltaTime, 0);
			playerAnimator.Play("walkRight");
		}

		if (Input.GetKey("left")) {
			transform.position += new Vector3(-playerSpeed*Time.deltaTime, 0);
			playerAnimator.Play("walkLeft");
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
		// DarkRealmImage.enabled = true;
	}
	if (DarkRealm == true) {
		// ignore input
		DarkRealm = false;
		// DarkRealmImage.enabled = false;
	}
}

}
