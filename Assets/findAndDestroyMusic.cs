using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findAndDestroyMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		dontDestroy bgMusic = (dontDestroy)FindObjectOfType(typeof(dontDestroy));
		Destroy(bgMusic.gameObject);
	}
	

}
