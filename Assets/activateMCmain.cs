using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMCmain : MonoBehaviour {
	public GameObject MCmainText;
	void OnDisable() {
		MCmainText.SetActive(true);
	}
}
