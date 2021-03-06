﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int playerHealth;
	public GameObject healthImage;
	private Image[] hearts;
	[HideInInspector]public bool reduceHealth;
	public float timeTakenHeartLoss = 1f;
	private float timeSinceHeartLoss;
	public Transform gameOverUI;
	
	void Start() {
		hearts = healthImage.GetComponentsInChildren<Image>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
		//	ReduceHealth();
		}
		if (playerHealth <= 0)
        {
            Debug.Log("The player is dead!");
        }
		if (reduceHealth) {
			timeSinceHeartLoss += Time.deltaTime;
			if (timeSinceHeartLoss > timeTakenHeartLoss) {
				reducePlayerHealth();
				GetComponent<PlayerControl>().hurtPlayerAnim();
				Debug.Log("Player Health:" + playerHealth);
				timeSinceHeartLoss = 0;
			}
		}
		
	}


	public void reducePlayerHealth() {
			playerHealth -= 1;
			foreach (Image heart in hearts) {
				if (heart.transform.GetSiblingIndex() == playerHealth) {
					heart.gameObject.SetActive(false);
				}
			}
			if (playerHealth == 0) {
				StopAllCoroutines();
				GetComponent<PlayerControl>().control = false;
				GetComponent<PlayerControl>().dead = true;
				GetComponent<Animator>().Play("dead");
				StartCoroutine(displayGameOver());
			}
		}
	
	IEnumerator displayGameOver() {
		yield return new WaitForSeconds(0.2f);
		Instantiate(gameOverUI);
	}

	// void OnTriggerEnter2D(Collider2D collider)
	// {
	// 	if(Collider2D.collider.tag == "possessedObject") {
	// 		ReduceHealth();
	// 	}
	// }
}
