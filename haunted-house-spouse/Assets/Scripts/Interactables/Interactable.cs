using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour, IClickable {

	bool colliding = false;
	public string Hint {
		get { return "Press spacebar to interact"; }
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "Player") {
			colliding = true;
			OnEnter ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.name == "Player") {
			colliding = false;
			OnExit ();
		}
	}

	void Update () {
		if (!colliding) return;
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnInteract ();
		}
	}

	protected void SetText (string content="") {
		InteractableText.instance.Content = content;
	}

	protected virtual void OnEnter () {
		SetText (Hint);
	}
	protected virtual void OnExit () {
		SetText ();
	}
	protected virtual void OnInteract () {}
	public virtual void Click (bool left) {}
	public virtual void Drag (bool left, Vector3 mousePosition) {}
	public virtual void Release (bool left) {}
}
