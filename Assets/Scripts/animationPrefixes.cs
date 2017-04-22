using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationPrefixes : MonoBehaviour {
	[HideInInspector]public string[][] allAnimations;
	
	private string[] upNames = new string[] {"IdleUp", "walkUp", "IdleUpHold", "walkUpHold"};
	private string[] rightNames = new string[] {"IdleRight", "walkRight", "IdleRightHold", "walkRightHold"};
	private string[] downNames = new string[] {"IdleDown", "walkDown", "IdleDownHold", "walkDownHold"};
	private string[] leftNames = new string[] {"IdleLeft", "walkLeft", "IdleLeftHold", "walkLeftHold"};

	// Use this for initialization
	void Start () {

		allAnimations = new string[][] {
			upNames,
			rightNames,
			downNames,
			leftNames
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
