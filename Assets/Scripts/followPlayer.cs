using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
	[HideInInspector]public GameObject player;
	public float speed = 1;
	private Vector3 direction;
	// Use this for initialization
	void Start () {
		StartCoroutine(getDirection());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += speed*Time.deltaTime*direction;
	}

	IEnumerator getDirection() {
		for (;;) {
			direction = (player.transform.position - transform.position).normalized;
			yield return new WaitForSeconds(0.5f);
		}
	}
}
