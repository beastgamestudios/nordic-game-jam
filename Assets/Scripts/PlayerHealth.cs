﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth;
	
	void Start() {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			ReduceHealth();
		}
		if (playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("The player is dead!");
        }
	}

	void ReduceHealth() {
		playerHealth -= 1;
	}
}