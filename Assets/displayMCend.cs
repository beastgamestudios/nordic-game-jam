using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayMCend : MonoBehaviour {
	public Transform MCend;
	void OnDisable() {
		Instantiate(MCend);
	}
}
