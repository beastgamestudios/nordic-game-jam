using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationPrefixes : MonoBehaviour {
	public Dictionary<string, string>[] allAnimations;
	
	private string[] keyNames = new string[] {"idle", "walk", "holdIdle", "walkHold"};
	private string[] upNames = new string[] {"upIdle", "walkUp", "IdleUpHold", "walkUpHold"};
	private string[] rightNames = new string[] {"rightIdle", "walkRight", "IdleRightHold", "walkRightHold"};
	private string[] downNames = new string[] {"downIdle", "walkDown", "IdleDownHold", "walkDownHold"};
	private string[] leftNames = new string[] {"leftIdle", "walkLeft", "IdleLeftHold", "walkLeftHold"};

	// Use this for initialization
	void Start () {
		Dictionary <string, string> up = defineAnimation(upNames);
		Dictionary <string, string> right = defineAnimation(rightNames);
		Dictionary <string, string> down = defineAnimation(downNames);
		Dictionary <string, string> left = defineAnimation(leftNames);

		allAnimations = new Dictionary<string, string>[] {up, right, down, left};
	}

	private Dictionary<string, string> defineAnimation(string[] animationNames) {
		return new Dictionary<string, string> {
			{keyNames[0], animationNames[0]},
			{keyNames[1], animationNames[1]},
			{keyNames[2], animationNames[2]},
			{keyNames[3], animationNames[3]}
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
