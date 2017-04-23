using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCastingAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().Play("casting");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
