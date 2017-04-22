using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationPrefixes : MonoBehaviour {
	[HideInInspector]public string[][] allAnimations;
	
	private string[] upNames = new string[] {"IdleUp", "walkUp", "IdleUpHold", "walkUpHold", "AttackUp", "HurtUp"};
	private string[] rightNames = new string[] {"IdleRight", "walkRight", "IdleRightHold", "walkRightHold", "AttackRight", "HurtRight"};
	private string[] downNames = new string[] {"IdleDown", "walkDown", "IdleDownHold", "walkDownHold", "AttackDown", "HurtDown"};
	private string[] leftNames = new string[] {"IdleLeft", "walkLeft", "IdleLeftHold", "walkLeftHold", "AttackLeft", "HurtLeft"};

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
