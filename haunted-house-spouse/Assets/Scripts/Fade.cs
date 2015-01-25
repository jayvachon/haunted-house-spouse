using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	Material material;
	bool fading = false;

	void Awake () {
		material = GetComponent<Renderer> ().material;
		material.color = new Color (0, 0, 0, 1);
	}

	void Start () {
		FadeOut ();
	}

	/*void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			FadeIn ();
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			FadeOut ();
		}
	}*/

	/*void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Application.LoadLevel ("Jay");
		}
	}*/

	public void FadeIn () {
		if (fading) return;
		StartCoroutine (CoFade (0, 1, 3));
	}

	public void FadeOut () {
		if (fading) return;
		StartCoroutine (CoFade (1, 0, 0.25f));
	}

	IEnumerator CoFade (float from, float to, float time) {
		
		fading = true;
		float eTime = 0;
		Color color = Color.black;

		while (eTime < time) {
			eTime += Time.deltaTime;
			color.a = Mathf.Lerp (from, to, Mathf.SmoothStep (0, 1, eTime / time));
			material.color = color;
			yield return null;
		} 

		OnEndFade ();
		fading = false;
	}

	void OnEndFade () {
		if (material.color.a >= 0.95f) {
			Application.LoadLevel ("House");
		}
	}
}
