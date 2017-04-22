using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObject : MonoBehaviour {
	public Vector3[] throwForce;
	[HideInInspector]public bool checkForGround;
	[HideInInspector]public GameObject player;
	[HideInInspector]public bool isPossessable;
	private enum directions{UP, RIGHT, DOWN, LEFT};
	private float groundYPos;
	public float groundDistanceBelowPlayer;
	private bool checkForGroundAbove;
	void Update() {
		if (checkForGround) {
			if (GetComponent<BoxCollider2D>().bounds.min.y <= groundYPos) {
				stopMovement();
				checkForGround = false;
				isPossessable = false;
				gameObject.layer = LayerMask.NameToLayer( "Default" );
			}
		}

		if (checkForGroundAbove) {
			if (GetComponent<Rigidbody2D>().velocity.y < 0) {
				stopMovement();
				checkForGroundAbove = false;
				isPossessable = false;
				gameObject.layer = LayerMask.NameToLayer( "Default" );
			}
		}
	}

	public void addThrowForce(int direction) {
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().gravityScale = 1f;
		GetComponent<Rigidbody2D>().AddForce(throwForce[direction]);

		if (direction == (int)directions.LEFT || direction == (int)directions.RIGHT) {
			checkForGround = true;
			groundYPos = findGroundYpos(direction);
		} else {
			if (direction == (int)directions.UP) {
				checkForGroundAbove = true;
			} else {
				groundYPos = transform.position.y - groundDistanceBelowPlayer;
				checkForGround = true;
			}
		}
		isPossessable = true;
		gameObject.layer = LayerMask.NameToLayer( "ignorePlayer" );
	}

	public void stopMovement() {
		GetComponent<Rigidbody2D>().gravityScale = 0;
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		GetComponent<Rigidbody2D>().isKinematic = true;
	}

	float findGroundYpos(int direction) {
		float boundsMin = player.GetComponent<BoxCollider2D>().bounds.min.y;
		return boundsMin;
	}
}
