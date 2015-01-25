using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	float fadeTime = 0.5f;
	Material material;
	bool fading = false;

	void Awake () {
		material = GetComponent<Renderer> ().material;
	}

	void FadeIn () {
		if (fading) return;
		StartCoroutine (CoFade (0, 1));
	}

	void FadeOut () {
		if (fading) return;
		StartCoroutine (CoFade (1, 0));
	}

	IEnumerator CoFade (float from, float to) {
		
		fading = true;
		float eTime = 0;
		Color color = Color.black;

		while (eTime < fadeTime) {
			eTime += Time.deltaTime;
			color.a = Mathf.Lerp (from, to, Mathf.SmoothStep (0, 1, eTime / fadeTime));
			material.color = color;
			yield return null;
		} 

		fading = false;
	}
}
