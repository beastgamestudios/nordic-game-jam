using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPossessedObjects : MonoBehaviour {
	private GameObject ghostInCollider;
	private enum directions{UP, RIGHT, DOWN, LEFT};

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("possessedObject")) {
			ghostInCollider = other.gameObject;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject == ghostInCollider) {
			ghostInCollider = null;
		}
	}

	public void checkGhostInRange(int direction) {
		if (direction == transform.GetSiblingIndex() && ghostInCollider != null) {
			Debug.Log("kill ghost");
		}
	}

}
