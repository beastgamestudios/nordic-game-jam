using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObject : MonoBehaviour {
	public Vector3[] throwForce;
	[HideInInspector]public bool checkForGround;
	[HideInInspector]public GameObject player;
	private enum directions{UP, RIGHT, DOWN, LEFT};
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

	public void addThrowForce(int direction) {
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().gravityScale = 1f;
		GetComponent<Rigidbody2D>().AddForce(throwForce[direction]);
		checkForGround = true;
		groundYPos = findGroundYpos(direction);
	}

	float findGroundYpos(int direction) {
		
		float boundsMin = player.GetComponent<BoxCollider2D>().bounds.min.y;
		return boundsMin;
	}
}
