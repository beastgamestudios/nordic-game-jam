using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float playerSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("down")) {
			transform.position += new Vector3(0, -playerSpeed*Time.deltaTime);
		}
		if (Input.GetKey("up")) {
			transform.position += new Vector3(0, playerSpeed*Time.deltaTime);
		}
		if (Input.GetKey("right")) {
			transform.position += new Vector3(playerSpeed*Time.deltaTime, 0);
		}
		if (Input.GetKey("left")) {
			transform.position += new Vector3(-playerSpeed*Time.deltaTime, 0);
		}		
	}
}
