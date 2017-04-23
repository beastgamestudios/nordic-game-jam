using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possessableMirror : MonoBehaviour {

	[HideInInspector]public bool isPossessable;
	private bool triggeredDarkRealm;
	GameObject player;
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		isPossessable = false;
	}
	void Update() {
		if (Input.GetButtonDown("X button")) {
			triggeredDarkRealm = true;
		}
		if (triggeredDarkRealm) {
			if (!player.GetComponent<PlayerControl>().inDarkRealm) {
				isPossessable = true;
			} else {
				isPossessable = false;
			}
		}
	}
}
