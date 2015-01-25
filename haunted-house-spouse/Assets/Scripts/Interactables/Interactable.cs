using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NetworkView))]
public class Interactable : MonoBehaviour, IClickable {

	bool colliding = false;
	public string Hint {
		get { return "Press spacebar to interact"; }
	}

	bool visible = false;
	protected bool Visible {
		get { return visible; }
		set {
			visible = value;
			renderer.enabled = visible;
			collider.enabled = visible;
		}
	}

	string content = "";
	public string Content {
		get { return content; }
		protected set { content = value; }
	}

	protected virtual string[] Options { get; set; }

	void OnTriggerEnter (Collider other) {
		if (NetworkManager.Ghost) return;
		if (other.name == "Player") {
			colliding = true;
			OnEnter ();
		}
	}

	void OnTriggerExit (Collider other) {
		if (NetworkManager.Ghost) return;
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

	public void SendContent (string newContent) {
		networkView.RPC ("ReceiveContent", RPCMode.Others, newContent);
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
	
	protected virtual void OnInteract () {
		SetText (Content);
	}

	public virtual void Click (bool left) {
		if (left && NetworkManager.Ghost) GhostClick ();
	}

	public virtual void GhostClick () {
		ActionsMenu.instance.ShowOptions (this, Options);	
	}

	public virtual void Drag (bool left, Vector3 mousePosition) {}
	public virtual void Release (bool left) {}
}
