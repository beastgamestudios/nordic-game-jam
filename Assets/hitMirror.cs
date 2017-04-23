using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitMirror : MonoBehaviour {
	private GameObject mirror;
	private Vector3 forceDirection;
	public float initialVelocity;
	// Use this for initialization
	public void addForceToMirror() {
		forceDirection = (mirror.transform.position - transform.position).normalized;
		mirror.GetComponent<Rigidbody2D>().AddForce(forceDirection*initialVelocity);
	}

	void Start() {
		mirror = GameObject.FindGameObjectWithTag("mirror");
		Debug.Log(mirror.transform.position);
		Debug.Log(mirror.gameObject.name);
	}

	void Update() {
		
	}
}
