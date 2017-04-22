﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectObject : MonoBehaviour {
	public Transform objectPrefab;
	public Transform possessedObjectPrefab;
	private string objectTag;

	// Use this for initialization
	void Start () {
		objectTag = objectPrefab.gameObject.tag;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == objectTag) {
			if (other.GetComponent<throwObject>().isPossessable) {
				other.GetComponent<Animator>().Play("turnPossessed");
				Debug.Log("possess object");
//				Instantiate(possessedObjectPrefab);

				gameObject.SetActive(false);
				other.GetComponent<throwObject>().stopMovement();
//				other.gameObject.SetActive(false);
			}
		}
	}
}
