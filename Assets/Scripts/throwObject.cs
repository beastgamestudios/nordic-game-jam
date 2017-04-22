using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObject : MonoBehaviour {
	public Vector2[] throwForce;
	[HideInInspector]public bool checkForGround;
	private float groundYPos;
	void Update() {
		if (checkForGround) {
			if (GetComponent<BoxCollider2D>().bounds.min.y <= groundYPos) {
				GetComponent<Rigidbody2D>().gravityScale = 0;
				GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				GetComponent<Rigidbody2D>().isKinematic = true;
				checkForGround = false;
			}
		}
	}

	public void addThrowForce(int direction, float ground) {
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().gravityScale = 1f;
		GetComponent<Rigidbody2D>().AddForce(throwForce[direction]);
		checkForGround = true;
		groundYPos = ground;
	}
}
