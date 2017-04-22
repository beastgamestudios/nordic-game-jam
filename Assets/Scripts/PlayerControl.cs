using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed;
	private Animator playerAnimator;
	private bool DarkRealm; 
	private bool isHolding;
	private Image DarkRealmImage;
	private Slider timerSlider;
	private string[][] allAnimations;
	private string[] currentDirectionAnimations;

	private enum directions{UP, RIGHT, DOWN, LEFT};
	private enum states{IDLE, WALK, IDLE_HOLD, WALK_HOLD};

	// Use this for initialization
	void Start () {
		DarkRealm = false;
		DarkRealmImage = GameObject.Find("Dark Realm").GetComponent<Image>();
		timerSlider = GameObject.Find("Timer Slider").GetComponent<Slider>();
		playerAnimator = GetComponent<Animator>();
		playerAnimator.enabled = true;
		allAnimations = GetComponent<animationPrefixes>().allAnimations;
		currentDirectionAnimations = allAnimations[(int)directions.DOWN];
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp("down") || Input.GetKeyUp("up") || Input.GetKeyUp("right") || Input.GetKeyUp("left")) {
			playIdleAnim();
		}

		if (Input.GetKey("down")) {
			transform.position += new Vector3(0, -playerSpeed*Time.deltaTime);
			currentDirectionAnimations = allAnimations[(int)directions.DOWN];
			playWalkAnim();
		}
		if (Input.GetKey("up")) {
			transform.position += new Vector3(0, playerSpeed*Time.deltaTime);
			currentDirectionAnimations = allAnimations[(int)directions.UP];
			playWalkAnim();
		}
		if (Input.GetKey("right")) {
			transform.position += new Vector3(playerSpeed*Time.deltaTime, 0);
			currentDirectionAnimations = allAnimations[(int)directions.RIGHT];
			playWalkAnim();
		}
		if (Input.GetKey("left")) {
			transform.position += new Vector3(-playerSpeed*Time.deltaTime, 0);
			currentDirectionAnimations = allAnimations[(int)directions.LEFT];
			playWalkAnim();
		}
		
		if (Input.GetKey("tab")) {
			Debug.Log("You are entering the Dark Realm");
			ChangeWorlds();
		}
	}

void playIdleAnim() {
	if (isHolding) {
		playerAnimator.Play(currentDirectionAnimations[(int)states.IDLE_HOLD]);
	} else {
		playerAnimator.Play(currentDirectionAnimations[(int)states.IDLE]);
	}
}

void playWalkAnim() {
	if (isHolding) {
		playerAnimator.Play(currentDirectionAnimations[(int)states.WALK_HOLD]);
	} else {
		playerAnimator.Play(currentDirectionAnimations[(int)states.WALK]);
	}
}

void ChangeWorlds() {
	// Code to change back and forth between Reality and Dark Realm
	if (DarkRealm == false) {
		DarkRealm = true;
		DarkRealmImage.enabled = true;
	}
	if (DarkRealm == true) {
		DarkRealm = false;
		DarkRealmImage.enabled = false;
	}
}

void DarkRealmCoolDown() {
		Debug.Log(timerSlider.value);
	}
}

}
