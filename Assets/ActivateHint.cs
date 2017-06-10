using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateHint : MonoBehaviour {
	public Image DRHint;
	// Use this for initialization
	void OnDisable () {
		DRHint.gameObject.SetActive(true);
		DRHint.GetComponent<changeHintText>().SwitchToDarkRealmHint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
