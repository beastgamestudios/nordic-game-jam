using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPossessedObjects : MonoBehaviour {
	private GameObject ghostInCollider;
	private enum directions{UP, RIGHT, DOWN, LEFT};
	private GameObject mirror;
	public GameObject player;
	public Transform vortex;
	public Transform familyMember;
	private bool mirrorHitOnce;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "possessedObject") {
			ghostInCollider = other.gameObject;
		}
		if (other.gameObject.tag == "mirror") {
			mirror = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject == ghostInCollider) {
			ghostInCollider = null;
		}
		if (other.gameObject == mirror) {
			mirror = null;
		}
	}

	public void checkGhostInRange(int direction) {
		if (direction == transform.GetSiblingIndex()) {
			if (ghostInCollider != null) {
				ghostInCollider.GetComponent<followPlayer>().enabled = false;
				if (ghostInCollider.gameObject.name == "mirror") {
					if (!mirrorHitOnce) {
						ghostInCollider.GetComponent<Animator>().Play("mirrorCrack");
						mirrorHitOnce = true;
					} else {
						ghostInCollider.GetComponent<Animator>().Play("mirrorFullyCracked");
						StartCoroutine(endAnimation());
					}
				} else {
					ghostInCollider.GetComponent<Animator>().Play("ghostDying");
					StartCoroutine(endAnimation());
				}
				
				
//				StartCoroutine(killGhost());
			}
			if (mirror != null) {
				player.GetComponent<hitMirror>().addForceToMirror();
			}
		}
	}

	void checkAllGhostsDead() {
		GameObject[] allGhosts = GameObject.FindGameObjectsWithTag("possessedObject");
		GameObject[] allObjects = GameObject.FindGameObjectsWithTag("objectTag");

		if (allGhosts.Length + allObjects.Length == 0) {
			player.GetComponent<PlayerControl>().control = false;
			Debug.Log("vortex spawn");
			Transform newVortex = Instantiate(vortex);
			newVortex.GetComponent<spawnFamilyMember>().familyMember = familyMember;
		}
	}

	IEnumerator endAnimation() {
		RuntimeAnimatorController ac = ghostInCollider.GetComponent<Animator>().runtimeAnimatorController;
		float animationLength = 0;
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
     	{
        	if(ac.animationClips[i].name == "ghostDying")        //If it has the same name as your clip
        	{
            	animationLength = ac.animationClips[i].length;
        	}
     	}
		yield return new WaitForSeconds(animationLength);
		ghostInCollider.gameObject.SetActive(false);
		checkAllGhostsDead();
	}




}
