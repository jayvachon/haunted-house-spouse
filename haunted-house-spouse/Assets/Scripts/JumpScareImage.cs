using UnityEngine;
using System.Collections;

public class JumpScareImage : MonoBehaviour {

	Renderer myRenderer;

	void Awake () {
		myRenderer = GetComponent<Renderer> ();
		myRenderer.enabled = false;
	}

	public void Show () {
		myRenderer.enabled = true;
		AudioManager.instance.Play ("jumpscare");
		Invoke ("Hide", 0.5f);
	}

	void Hide () {
		myRenderer.enabled = false;
	}
}
