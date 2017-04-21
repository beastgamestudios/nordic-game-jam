using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPossessability : MonoBehaviour {
	//becomes true when player throws object
	//cannot be possessed by ghost when false
	[HideInInspector]public bool isPossessable;
	[HideInInspector]public float throwTime;
	public float timeSinceThrow;

	void Update() {
		if (isPossessable) {
			timeSinceThrow += Time.deltaTime;

			//if object has landed it can no longer be possessed
			if (timeSinceThrow > throwTime) {
				isPossessable = false;
				timeSinceThrow = 0;
			}
		}
	}
	
}
