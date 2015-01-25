using UnityEngine;
using System.Collections;

public class JumpScareImage : MonoBehaviour {

	Renderer renderer;

	void Awake () {
		renderer = GetComponent<Renderer> ();
		renderer.enabled = false;
	}

	public void Show () {
		renderer.enabled = true;
		Invoke ("Hide", 0.5f);
	}

	void Hide () {
		renderer.enabled = false;
	}
}
