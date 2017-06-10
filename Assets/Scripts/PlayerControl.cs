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
	[HideInInspector]public bool inDarkRealm; 
	private bool isHolding;
	public GameObject DarkRealmObject;
	public GameObject DarkRealmTimer;
	public Slider timerSlider;
	public GameObject[] Ghosts;
	private Collider2D objectColliderBoxPlayerIsIn;
	private Transform objectToBeLifted;
	[HideInInspector]public string[][] allAnimations;
	[HideInInspector]public string[] currentDirectionAnimations;
	private bool coroutineStarted;
	[HideInInspector]public bool dead;
	private enum directions{UP, RIGHT, DOWN, LEFT};
	private enum states{IDLE, WALK, IDLE_HOLD, WALK_HOLD, ATTACK, HURT};
	public AudioSource slashSound;
	public AudioSource hurtSound;
	public AudioSource triggerSound;
	private bool intoDarkRealm = false;
	public GameObject DRHint;
	void Awake() {
		control = true;
		
	}

	// Use this for initialization
	void Start () {
	//	gameObject.AddComponent<animationPrefixes>();
		inDarkRealm = false;
		Ghosts = GameObject.FindGameObjectsWithTag("ghost");
//		ghostSprite = Ghost.GetComponent<SpriteRenderer>() as SpriteRenderer;
		playerAnimator = GetComponent<Animator>();
		playerAnimator.enabled = true;
		setAnimationNames();
		currentDirectionAnimations = allAnimations[(int)directions.DOWN];
	}
	
	// Update is called once per frame
	void Update () {
		if (control) {

		Vector2 getInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (Mathf.Abs(getInput.x) < 0.5f && Mathf.Abs(getInput.y) < 0.5f) {
			playIdleAnim();
		} else if (Mathf.Abs(getInput.x) > Mathf.Abs(getInput.y)) {
			if (getInput.x > 0) {
				currentDirectionAnimations = allAnimations[(int)directions.RIGHT];
			} else {
				currentDirectionAnimations = allAnimations[(int)directions.LEFT];
			}
			transform.position += new Vector3(getInput.x, getInput.y)*playerSpeed*Time.deltaTime;
			playWalkAnim();
		} else {
			if (getInput.y > 0) {
				currentDirectionAnimations = allAnimations[(int)directions.UP];
			} else {
				currentDirectionAnimations = allAnimations[(int)directions.DOWN];
			}
			transform.position += new Vector3(getInput.x, getInput.y)*playerSpeed*Time.deltaTime;
			playWalkAnim();
		}

		if (Input.GetButtonDown("A button") && !inDarkRealm) {
			if (isHolding) {
				isHolding = false;
				throwObject();
				objectToBeLifted.parent = null;
				playIdleAnim();
			} else {
				checkForObject();
			}
		}

		if (Input.GetButtonDown("B button") && !inDarkRealm && !isHolding) {
			slashSound.Play();
			control = false;
			playerAnimator.Play(currentDirectionAnimations[(int)states.ATTACK]);
			animationPlaying = currentDirectionAnimations[(int)states.ATTACK];
			StartCoroutine(endAnimation());
			checkForGhosts();
		}
		
		if (Input.GetButtonDown("X button")) {
			SwitchWorlds();
		}
		
	}

	if (inDarkRealm) {
		DarkRealmCoolDown();
		foreach (GameObject ghost in Ghosts) {
			ghost.GetComponent<SpriteRenderer>().enabled = true;
//			ghost.GetComponent<FadeImageOut>().recolor();
//			StopCoroutine(ghost.GetComponent<FadeImageOut>().fadeOut(2f));

		}
	}
	if (!inDarkRealm) {
		DarkRealmRecharge();
		foreach (GameObject ghost in Ghosts) {
			if (intoDarkRealm) {
				ghost.GetComponent<SpriteRenderer>().enabled = false;
//				StartCoroutine(ghost.GetComponent<FadeImageOut>().fadeOut(2f));

			}
		}
	}

}

void setAnimationNames () {
		string[] upNames = new string[] {"IdleUp", "walkUp", "IdleUpHold", "walkUpHold", "AttackUp", "HurtUp"};
		string[] rightNames = new string[] {"IdleRight", "walkRight", "IdleRightHold", "walkRightHold", "AttackRight", "HurtRight"};
		string[] downNames = new string[] {"IdleDown", "walkDown", "IdleDownHold", "walkDownHold", "AttackDown", "HurtDown"};
		string[] leftNames = new string[] {"IdleLeft", "walkLeft", "IdleLeftHold", "walkLeftHold", "AttackLeft", "HurtLeft"};

		allAnimations = new string[][] {
			upNames,
			rightNames,
			downNames,
			leftNames
		};
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
	if (!dead) {
		hurtSound.Play();
		control = false;
		playerAnimator.Play(currentDirectionAnimations[(int)states.HURT]);
		animationPlaying = currentDirectionAnimations[(int)states.HURT];
		StartCoroutine(endAnimation());
	}
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
		triggerSound.Play();
		control = false;
		playerAnimator.Play("enterDarkRealm");
		animationPlaying = "enterDarkRealm";
		StartCoroutine(endAnimation());
		
		inDarkRealm = true;
		DarkRealmObject.SetActive(true);
		Debug.Log("You are entering the Dark Realm");

		// if (DRHint != null)
		// 	DRHint.GetComponent<changeHintText>().SwitchToDarkRealmHint();	
	} else {
		GetComponent<PlayerHealth>().reduceHealth = false;
//		StopCoroutine(GetComponent<PlayerHealth>().CallReduceHealth());
		coroutineStarted = false;
		inDarkRealm = false;
		DarkRealmObject.SetActive(false);
		Debug.Log("You are going back to Reality");

		if (DRHint != null)
		 	DRHint.gameObject.SetActive(false);	
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
