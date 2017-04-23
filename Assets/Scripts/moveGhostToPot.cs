using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGhostToPot : MonoBehaviour {
	private GameObject flowerPot;
	private Vector3 direction;
	private float speed;
	[HideInInspector]public GameObject player;
	// Use this for initialization
	void Start () {
		speed = GetComponent<followPath>().moveSpeed;
		GetComponent<followPath>().enabled = false;
		flowerPot = GameObject.FindGameObjectWithTag("objectTag");
		direction = flowerPot.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Time.deltaTime*speed*direction.normalized;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == flowerPot) {
			GetComponent<detectObject>().possessObject(other, player);
			player.GetComponent<PlayerControl>().control = true;
		}
	}
}
