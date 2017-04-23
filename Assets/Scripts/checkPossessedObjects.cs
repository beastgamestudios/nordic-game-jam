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
				if (ghostInCollider.gameObject.name == "mirror") {
					if (!mirrorHitOnce) {
						ghostInCollider.GetComponent<Animator>().Play("mirrorCracked");
						mirrorHitOnce = true;
						StartCoroutine(mirrorFlinch());
					} else {
						ghostInCollider.GetComponent<followPlayer>().enabled = false;
						ghostInCollider.GetComponent<Animator>().Play("mirrorFullyCracked");
						StartCoroutine(endAnimation("mirrorFullyCracked"));
					}
				} else {
					ghostInCollider.GetComponent<followPlayer>().enabled = false;
					ghostInCollider.GetComponent<Animator>().Play("ghostDying");
					StartCoroutine(endAnimation("ghostDying"));
				}
				
				
//				StartCoroutine(killGhost());
			}
			if (mirror != null) {
				player.GetComponent<hitMirror>().addForceToMirror();
			}
		}
	}

	IEnumerator mirrorFlinch() {
		Vector3 direction = (ghostInCollider.transform.position - transform.position).normalized;
		for (int i = 0; i < 10; i++) {
			yield return null;
			ghostInCollider.transform.position += 3f*direction*Time.deltaTime;
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

	IEnumerator endAnimation(string animationName) {
		RuntimeAnimatorController ac = ghostInCollider.GetComponent<Animator>().runtimeAnimatorController;
		float animationLength = 0;
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
     	{
        	if(ac.animationClips[i].name == animationName)        //If it has the same name as your clip
        	{
            	animationLength = ac.animationClips[i].length;
        	}
     	}
		yield return new WaitForSeconds(animationLength);
		ghostInCollider.gameObject.SetActive(false);
		if (animationName == "ghostDying") {
			checkAllGhostsDead();
		} else {
			player.GetComponent<PlayerControl>().control = false;
			Debug.Log("vortex spawn");
			Transform newVortex = Instantiate(vortex);
			newVortex.GetComponent<spawnFamilyMember>().familyMember = familyMember;
		}
	}




}
