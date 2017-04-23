using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayHappyText : MonoBehaviour {
	public Transform happyText;
	public string happyAnimationName;
	// Use this for initialization
	void Start () {
		Transform text = Instantiate(happyText);
		text.GetComponentInChildren<Animator>().Play(happyAnimationName);
		text.GetComponentInChildren<displayText>().player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
