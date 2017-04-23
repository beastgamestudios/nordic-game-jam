using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createDoor : MonoBehaviour {
	public Transform door;
	public string sceneName;
	// Use this for initialization
	void Start () {
		Transform newDoor = Instantiate(door);
		newDoor.GetComponent<changeScene>().sceneName = sceneName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
