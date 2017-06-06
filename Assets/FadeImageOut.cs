using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImageOut : MonoBehaviour {
	private Color initialColor;
	void Start() {
		initialColor = GetComponent<SpriteRenderer>().color;
	}
	public IEnumerator fadeOut(float timeTaken) {
		float timePassed = 0;
		while (timePassed < timeTaken) {
			GetComponent<SpriteRenderer>().color = Color.Lerp(initialColor, new Color(initialColor.r, initialColor.g, initialColor.b, 0), timePassed/timeTaken);
			timePassed += Time.deltaTime;
			yield return null;
		}
	}

	public void recolor() {
		GetComponent<SpriteRenderer>().color = initialColor;
	}
}
