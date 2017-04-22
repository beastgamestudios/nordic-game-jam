using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script should only be active when player is holding down A button
public class liftObject : MonoBehaviour {
	private enum relativePosition{LEFT, UP, RIGHT, DOWN};
	public float axisThreshold;	//required magnitude of joystick pull to get lift response
	
	void OnTriggerStay2D(Collider2D other) {
		
		switch (other.transform.GetSiblingIndex()) {
			case ((int)relativePosition.LEFT):
			if (Input.GetAxis("Horizontal") < -0.5f) {
				//GetComponent<Animator>().Play("liftObjectRight");
				//other.GetComponent<Animator>().Play("objectRiseLeft");
				//player.GetComponent<PlayerControl>().isLifting = true;
				//other.transform.SetParent(transform);
			}
			break;
			case ((int)relativePosition.UP):
			if (Input.GetAxis("Vertical") > 0.5f) {
				//GetComponent<Animator>().Play("liftObjectDown");
				//other.GetComponent<Animator>().Play("objectRiseUp");
				//player.GetComponent<PlayerControl>().isLifting = true;
				//other.transform.SetParent(transform);
			}
			break;
			case ((int)relativePosition.RIGHT):
			if (Input.GetAxis("Horizontal") > 0.5f) {
				//GetComponent<Animator>().Play("liftObjectLeft");
				//other.GetComponent<Animator>().Play("objectRiseRight");
				//player.GetComponent<PlayerControl>().isLifting = true;
				//other.transform.SetParent(transform);
			}
			break;
			case ((int)relativePosition.DOWN):
			if (Input.GetAxis("Vertical") < -0.5f) {
				//GetComponent<Animator>().Play("liftObjectUp");
				//other.GetComponent<Animator>().Play("objectRiseDown");
				//player.GetComponent<PlayerControl>().isLifting = true;
				//other.transform.SetParent(transform);
			}
			break;
		}
	}


}
