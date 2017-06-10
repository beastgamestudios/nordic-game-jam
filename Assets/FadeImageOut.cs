using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImageOut : MonoBehaviour {
	private Color initialColorImage;
	private Color initialColorText;
	private Color fadedColorImage;
	private Color fadedColorText;
	public float fadeTime;
	public float showTime;
	public float nonShowTime;

	void OnEnable() {
		initialColorImage = GetComponent<Image>().color;
		initialColorText = GetComponentInChildren<Text>().color;
		fadedColorImage = new Color(initialColorImage.r, initialColorImage.g, initialColorImage.b, 0);
		fadedColorText = new Color(initialColorImage.r, initialColorImage.g, initialColorImage.b, 0);
		GetComponent<Image>().color = fadedColorImage;
		GetComponentInChildren<Text>().color = fadedColorText;
		StartCoroutine(incrementNonShowTime());
	}

	void Start() {
		
	}

	public IEnumerator fadeIn() {
		float timePassed = 0;
		while (timePassed < fadeTime) {
			GetComponent<Image>().color = Color.Lerp(fadedColorImage, initialColorImage, timePassed/fadeTime);
			GetComponentInChildren<Text>().color = Color.Lerp(fadedColorText, initialColorText, timePassed/fadeTime);;
			timePassed += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(incrementShowTime());
	}
	public IEnumerator fadeOut() {
		float timePassed = 0;
		while (timePassed < fadeTime) {
			GetComponent<Image>().color = Color.Lerp(initialColorImage, fadedColorImage, timePassed/fadeTime);;
			GetComponentInChildren<Text>().color = Color.Lerp(initialColorText, fadedColorText, timePassed/fadeTime);;
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

}
