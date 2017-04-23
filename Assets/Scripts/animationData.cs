using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationData : MonoBehaviour {

	[HideInInspector]public string[][] allAnimations;
	
	private string[] upNames;
	private string[] rightNames;
	private string[] downNames;
	private string[] leftNames;

	// Use this for initialization
	void Start () {
		upNames = new string[] {"IdleUp", "walkUp", "IdleUpHold", "walkUpHold", "AttackUp", "HurtUp"};
		rightNames = new string[] {"IdleRight", "walkRight", "IdleRightHold", "walkRightHold", "AttackRight", "HurtRight"};
		downNames = new string[] {"IdleDown", "walkDown", "IdleDownHold", "walkDownHold", "AttackDown", "HurtDown"};
		leftNames = new string[] {"IdleLeft", "walkLeft", "IdleLeftHold", "walkLeftHold", "AttackLeft", "HurtLeft"};

		allAnimations = new string[][] {
			upNames,
			rightNames,
			downNames,
			leftNames
		};
	}
}
