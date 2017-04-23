using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadBrothersRoom : MonoBehaviour {

void OnDisable()
	{
		SceneManager.LoadScene("Main");
	}
}
