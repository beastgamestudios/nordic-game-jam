using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed;
	public float objectHeightAbovePlayer;
	private bool control;
	private string animationPlaying;
	private Animator playerAnimator;
	private bool DarkRealm; 
	private bool isHolding;
	private Image DarkRealmImage;
	private Slider timerSlider;
	private Collider2D objectColliderBoxPlayerIsIn;
	private Transform objectToBeLifted;
	private string[][] allAnimations;
	private string[] currentDirectionAnimations;

	private enum directions{UP, RIGHT, DOWN, LEFT};
	private enum states{IDLE, WALK, IDLE_HOLD, WALK_HOLD, ATTACK};

	// Use this for initialization
	void Start () {
		DarkRealm = false;
//		DarkRealmImage = GameObject.Find("Dark Realm").GetComponent<Image>();
//		timerSlider = GameObject.Find("Timer Slider").GetComponent<Slider>();
		playerAnimator = GetComponent<Animator>();
		playerAnimator.enabled = true;
		allAnimations = GetComponent<animationPrefixes>().allAnimations;
		currentDirectionAnimations = allAnimations[(int)directions.DOWN];
		control = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (control) {
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

		if (Input.GetKeyDown("a")) {
			
			if (isHolding) {
				isHolding = false;
				//throw object
				objectToBeLifted.parent = null;
				playIdleAnim();
			} else {
				checkForObject();
			}
		}

		if (Input.GetKeyDown("b")) {
			control = false;
			playerAnimator.Play(currentDirectionAnimations[(int)states.ATTACK]);
			animationPlaying = currentDirectionAnimations[(int)states.ATTACK];
			StartCoroutine(endAnimation());
		}
		
		if (Input.GetKey("tab")) {
			Debug.Log("You are entering the Dark Realm");
			ChangeWorlds();
		}
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

IEnumerator endAnimation() {
	RuntimeAnimatorController ac = playerAnimator.runtimeAnimatorController;
	float animationLength = 0;
	for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
     {
         if(ac.animationClips[i].name == animationPlaying)        //If it has the same name as your clip
         {
             animationLength = ac.animationClips[i].length;
         }
     }
	yield return new WaitForSeconds(animationLength);
	control = true;
	animationPlaying = null;
	playIdleAnim();
}

void checkForObject() {
	if (objectColliderBoxPlayerIsIn != null) {
		switch (objectColliderBoxPlayerIsIn.transform.GetSiblingIndex()) {
		case ((int)directions.UP):
		if (currentDirectionAnimations == allAnimations[(int)directions.UP]) {
			isHolding = true;
			playIdleAnim();
			setObjectToPlayer();
		}
		break;
		case ((int)directions.RIGHT):
		if (currentDirectionAnimations == allAnimations[(int)directions.RIGHT]) {
			isHolding = true;
			playIdleAnim();
			setObjectToPlayer();
		}
		break;
		case ((int)directions.DOWN):
		if (currentDirectionAnimations == allAnimations[(int)directions.DOWN]) {
			isHolding = true;
			playIdleAnim();
			setObjectToPlayer();
		}
		break;
		case ((int)directions.LEFT):
		if (currentDirectionAnimations == allAnimations[(int)directions.LEFT]) {
			isHolding = true;
			playIdleAnim();
			setObjectToPlayer();
		}
		break;
		}
	}
}

void setObjectToPlayer() {
	objectToBeLifted = objectColliderBoxPlayerIsIn.transform.parent;
	objectToBeLifted.SetParent(transform);
	objectToBeLifted.localPosition = new Vector2(0, objectHeightAbovePlayer);
}

void OnTriggerStay2D(Collider2D other) {
	if (other.gameObject.CompareTag("liftObjectCollider")) {
		Debug.Log(other.gameObject.name);
		objectColliderBoxPlayerIsIn = other;
	}
}

void OnTriggerExit2D(Collider2D other) {
	if (other == objectColliderBoxPlayerIsIn) {
		objectColliderBoxPlayerIsIn = null;
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

