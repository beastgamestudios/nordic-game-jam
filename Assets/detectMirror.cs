using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectMirror : MonoBehaviour {
	private string objectTag;
	public AudioSource possessSound;

	// Use this for initialization
	void Start () {
		objectTag = "mirror";
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == objectTag) {
			if (other.GetComponent<possessableMirror>().isPossessable) {
				Debug.Log("mirror is possessed");
				possessSound.Play();
				other.GetComponent<Animator>().Play("mirrorPossessed");
				gameObject.SetActive(false);

				//possess object
				//other.GetComponent<>().stopMovement();
				other.gameObject.tag = "possessedObject";
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				//player.GetComponent<hitMirror>().enabled = false;
				other.gameObject.AddComponent<followPlayer>();
				other.gameObject.GetComponent<followPlayer>().player = player;
				other.GetComponent<BoxCollider2D>().isTrigger = true;
				//other.GetComponent<>().enabled = false;
				//other.GetComponent<BoxCollider2D>().isTrigger = true;
				//destroy colliders which activate lift mechanic
				//foreach (Transform child in other.transform) {
				//	Destroy(child.gameObject);
				//}
			}
		}
	}
}
