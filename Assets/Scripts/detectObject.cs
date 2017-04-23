using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectObject : MonoBehaviour {
	public Transform objectPrefab;
	private string objectTag;

	// Use this for initialization
	void Start () {
		objectTag = objectPrefab.gameObject.tag;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == objectTag) {
			if (other.GetComponent<throwObject>().isPossessable) {
				other.GetComponent<Animator>().Play("turnPossessed");
//				Instantiate(possessedObjectPrefab);
				gameObject.SetActive(false);

				//possess object
				other.GetComponent<throwObject>().stopMovement();
				other.gameObject.tag = "possessedObject";
				
				other.gameObject.AddComponent<followPlayer>();
				other.gameObject.GetComponent<followPlayer>().player = other.GetComponent<throwObject>().player;
				other.GetComponent<throwObject>().enabled = false;
				other.GetComponent<BoxCollider2D>().isTrigger = true;
				//destroy colliders which activate lift mechanic
				foreach (Transform child in other.transform) {
					Destroy(child.gameObject);
				}
			}
		}
	}

	public void possessObject(Collider2D other, GameObject player) {
		other.GetComponent<Animator>().Play("turnPossessed");
//		Instantiate(possessedObjectPrefab);
		gameObject.SetActive(false);

				//possess object
		other.GetComponent<throwObject>().stopMovement();
		other.gameObject.tag = "possessedObject";
				
		other.gameObject.AddComponent<followPlayer>();
		other.gameObject.GetComponent<followPlayer>().player = player;
		other.GetComponent<throwObject>().enabled = false;
		other.GetComponent<BoxCollider2D>().isTrigger = true;
				//destroy colliders which activate lift mechanic
		foreach (Transform child in other.transform) {
			Destroy(child.gameObject);
		}

	}

}
