using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImageOut : MonoBehaviour {
	private Color initialColor;
	public float fadeTime;
	public float showTime;
	public float nonShowTime;

	void Awake() {
		initialColor = GetComponent<Image>().color;
		GetComponent<Image>().color = new Color(initialColor.r, initialColor.g, initialColor.b, 0);
		GetComponentInChildren<Text>().color = new Color(initialColor.r, initialColor.g, initialColor.b, 0);
	}

	void Start() {
		StartCoroutine(fadeIn());
	}

	public IEnumerator fadeIn() {
		float timePassed = 0;
		while (timePassed < fadeTime) {
			Color newColor = Color.Lerp(new Color(initialColor.r, initialColor.g, initialColor.b, 0), initialColor, timePassed/fadeTime);
			GetComponent<Image>().color = newColor;
			GetComponentInChildren<Text>().color = newColor;
			timePassed += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(incrementShowTime());
	}
	public IEnumerator fadeOut() {
		float timePassed = 0;
		while (timePassed < fadeTime) {
			Color newColor = Color.Lerp(initialColor, new Color(initialColor.r, initialColor.g, initialColor.b, 0), timePassed/fadeTime);
			GetComponent<Image>().color = newColor;
			GetComponentInChildren<Text>().color = newColor;
			timePassed += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(incrementNonShowTime());
	}

	IEnumerator incrementShowTime() {
		float timePassed = 0;
		while (timePassed < showTime) {
			timePassed += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(fadeOut());
	}

	IEnumerator incrementNonShowTime() {
		float timePassed = 0;
		while (timePassed < nonShowTime) {
			timePassed += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(fadeIn());
	}

	public void recolor() {
		GetComponent<SpriteRenderer>().color = initialColor;
	}
}
