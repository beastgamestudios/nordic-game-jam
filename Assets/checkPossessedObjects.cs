using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPossessedObjects : MonoBehaviour {
	private GameObject ghostInCollider;
	private enum directions{UP, RIGHT, DOWN, LEFT};
	private GameObject deadGhostWalking;
	public GameObject player;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "possessedObject") {
			ghostInCollider = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject == ghostInCollider) {
			ghostInCollider = null;
		}
	}

	public void checkGhostInRange(int direction) {
		if (direction == transform.GetSiblingIndex()) {
			if (ghostInCollider != null) {
				deadGhostWalking = ghostInCollider;
				deadGhostWalking.gameObject.SetActive(false);
				checkAllGhostsDead();
//				StartCoroutine(killGhost());
			}
		}
	}

	void checkAllGhostsDead() {
		GameObject[] allGhosts = GameObject.FindGameObjectsWithTag("possessedObject");
		if (allGhosts.Length == 0) {
			Debug.Log("ghost death animation");
			player.GetComponent<PlayerControl>().control = false;
		}
	}

	IEnumerator makeVortex() {
		yield return new WaitForSeconds(2f);
		Debug.Log("spawn vortex");
	}

	IEnumerator killGhost() {
		yield return new WaitForSeconds(0.5f);
		deadGhostWalking.gameObject.SetActive(false);
	}

}
