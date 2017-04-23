using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayVictoryScreen : MonoBehaviour {
	public Transform victoryUI;

	void OnDisable()
	{
		Instantiate(victoryUI);
	}

}
