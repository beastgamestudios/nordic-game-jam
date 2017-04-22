using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed;
	public float objectHeightAbovePlayer;
	[HideInInspector]public bool control;
	private string animationPlaying;
	private Animator playerAnimator;
	private bool inDarkRealm; 
	private bool isHolding;
	public GameObject DarkRealmObject;
	public GameObject DarkRealmTimer;
	public Slider timerSlider;
	public GameObject Ghost;
	private SpriteRenderer ghostSprite; 
	private Collider2D objectColliderBoxPlayerIsIn;
	private Transform objectToBeLifted;
	[HideInInspector]public string[][] allAnimations;
	[HideInInspector]public string[] currentDirectionAnimations;
	private bool coroutineStarted;

	private enum directions{UP, RIGHT, DOWN, LEFT};
	private enum states{IDLE, WALK, IDLE_HOLD, WALK_HOLD, ATTACK, HURT};

	void Awake() {
		control = true;
	}

	// Use this for initialization
	void Start () {
		inDarkRealm = false;
		ghostSprite = Ghost.GetComponent<SpriteRenderer>() as SpriteRenderer;
		playerAnimator = GetComponent<Animator>();
		playerAnimator.enabled = true;
		allAnimations = GetComponent<animationPrefixes>().allAnimations;
		currentDirectionAnimations = allAnimations[(int)directions.DOWN];
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

		if (Input.GetKeyDown("a") && !inDarkRealm) {
			
			if (isHolding) {
				isHolding = false;
				throwObject();
				objectToBeLifted.parent = null;
				playIdleAnim();
			} else {
				checkForObject();
			}
		}

		if (Input.GetKeyDown("b") && !inDarkRealm && !isHolding) {
			control = false;
			playerAnimator.Play(currentDirectionAnimations[(int)states.ATTACK]);
			animationPlaying = currentDirectionAnimations[(int)states.ATTACK];
			StartCoroutine(endAnimation());
			checkForGhosts();
		}
		
		if (Input.GetKeyDown("tab")) {
			SwitchWorlds();
			if (isHolding) {
				objectToBeLifted.transform.parent = null;
				objectToBeLifted.GetComponent<throwObject>().addThrowForce((int)directions.DOWN);
				isHolding = false;
				playIdleAnim();
			}
		}
		
	}

	if (inDarkRealm) {
		DarkRealmCoolDown();
		ghostSprite.enabled = true;
	}
	if (!inDarkRealm) {
		DarkRealmRecharge();
		ghostSprite.enabled = false;
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

void OnTriggerEnter2D(Collider2D other) {
	if (other.gameObject.CompareTag("possessedObject")) {
		hurtPlayerAnim();
		GetComponent<PlayerHealth>().reducePlayerHealth();
	}
}

public void hurtPlayerAnim() {
	control = false;
	playerAnimator.Play(currentDirectionAnimations[(int)states.HURT]);
	animationPlaying = currentDirectionAnimations[(int)states.HURT];
	StartCoroutine(endAnimation());
}

void OnTriggerStay2D(Collider2D other) {
	if (other.gameObject.CompareTag("liftObjectCollider")) {
		objectColliderBoxPlayerIsIn = other;
	}
}

void OnTriggerExit2D(Collider2D other) {
	if (other == objectColliderBoxPlayerIsIn) {
		objectColliderBoxPlayerIsIn = null;
	}
}

void throwObject() {
	objectToBeLifted.GetComponent<throwObject>().player = gameObject;
	if (currentDirectionAnimations == allAnimations[(int)directions.UP]) {
		objectToBeLifted.GetComponent<throwObject>().addThrowForce((int)directions.UP);
	}
	if (currentDirectionAnimations == allAnimations[(int)directions.RIGHT]) {
		objectToBeLifted.GetComponent<throwObject>().addThrowForce((int)directions.RIGHT);
	}
	if (currentDirectionAnimations == allAnimations[(int)directions.DOWN]) {
		objectToBeLifted.GetComponent<throwObject>().addThrowForce((int)directions.DOWN);
	}
	if (currentDirectionAnimations == allAnimations[(int)directions.LEFT]) {
		objectToBeLifted.GetComponent<throwObject>().addThrowForce((int)directions.LEFT);
	}
	
}

void checkForGhosts() {
	checkPossessedObjects[] attackColliders = gameObject.GetComponentsInChildren<checkPossessedObjects>();
	int i = 0;
	for (; i < allAnimations.Length; i++) {
		if (currentDirectionAnimations == allAnimations[i]) {
			break;
		}
	}
	foreach (checkPossessedObjects collider in attackColliders) {
		collider.checkGhostInRange(i);
	}
}

void SwitchWorlds() {
	// Code to change back and forth between Reality and Dark Realm
	if (inDarkRealm == false) {
		//trigger animation
		control = false;
		playerAnimator.Play("enterDarkRealm");
		animationPlaying = "enterDarkRealm";
		StartCoroutine(endAnimation());
		
		inDarkRealm = true;
		DarkRealmObject.SetActive(true);
		Debug.Log("You are entering the Dark Realm");	
	} else {
		GetComponent<PlayerHealth>().reduceHealth = false;
//		StopCoroutine(GetComponent<PlayerHealth>().CallReduceHealth());
		coroutineStarted = false;
		inDarkRealm = false;
		DarkRealmObject.SetActive(false);
		Debug.Log("You are going back to Reality");
	}
}

void DarkRealmCoolDown() {
	if (control) {
		timerSlider.value -= Time.deltaTime;
		DarkRealmTimer.SetActive(true); //can see the timer in dark realm
		if (timerSlider.value <= 0 && !coroutineStarted) {
			GetComponent<PlayerHealth>().reduceHealth = true;
		//	StartCoroutine(GetComponent<PlayerHealth>().CallReduceHealth());
			coroutineStarted = true;
		}
	}
}




void DarkRealmRecharge() {
		timerSlider.value += Time.deltaTime;
		if (timerSlider.value >= timerSlider.maxValue) {
			DarkRealmTimer.SetActive(false); //timer disappears when full
		}
}

}
