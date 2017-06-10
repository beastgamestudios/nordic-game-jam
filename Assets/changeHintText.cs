using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeHintText : MonoBehaviour {
	public string textInDarkRealm;
	public string textOutsideDarkRealm;
	public GameObject player;
	void OnEnable() {
		if (player.GetComponent<PlayerControl>().inDarkRealm)
			SwitchToDarkRealmHint();
		else
			SwitchToRealRealmHint();
	}

	public void SwitchToDarkRealmHint() {
		GetComponentInChildren<Text>().text = textInDarkRealm;
	}

	public void SwitchToRealRealmHint() {
		GetComponentInChildren<Text>().text = textOutsideDarkRealm;
	}
}
