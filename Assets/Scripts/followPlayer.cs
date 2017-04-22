using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
	[HideInInspector]public GameObject player;
	public float speed = 1;
	private Vector3 direction;
	private bool startMoving;
	// Use this for initialization
	void Start () {
		StartCoroutine(getDirection());
		StartCoroutine(pause());
		GetComponent<Rigidbody2D>().isKinematic = false;
		gameObject.layer = LayerMask.NameToLayer( "Default" );
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoving) {
			transform.position += speed*Time.deltaTime*direction;
		}
	}

	IEnumerator getDirection() {
		for (;;) {
			direction = (player.transform.position - transform.position).normalized;
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator pause() {
		yield return new WaitForSeconds(0.5f);
		startMoving = true;
	}

}
