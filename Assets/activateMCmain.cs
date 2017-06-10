using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMCmain : MonoBehaviour {
	public GameObject MCmainText;
	public GameObject DRHint;

	void OnEnable() {
		if (DRHint != null)
			DRHint.gameObject.SetActive(false);
	}
	void OnDisable() {
		MCmainText.SetActive(true);
	}
}
