using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFamilyMember : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine(endAnimation());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator endAnimation() {
		RuntimeAnimatorController ac = GetComponent<Animator>().runtimeAnimatorController;
		float animationLength = 0;
		for(int i = 0; i<ac.animationClips.Length; i++)                 //For all animations
     	{
        	if(ac.animationClips[i].name == "spawnVortex")        //If it has the same name as your clip
        	{
            	animationLength = ac.animationClips[i].length;
        	}
     	}
		yield return new WaitForSeconds(animationLength);
		Debug.Log("spawn family member");
	}
}
