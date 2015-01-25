using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NetworkView))]
public class Player : MonoBehaviour {

	public Fade fade;

	float speed = 5f;
	bool canHide = false;
	public bool CanHide {
		get { return canHide; }
		set { canHide = value; }
	}

	bool hiding = false;
	bool canMove = true;

	void Update () {
		if (NetworkManager.Ghost) return;
		
		if (!hiding && canMove) {
			float translation = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			transform.Translate (translation, 0, 0);
		}

		if (CanHide) {
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				hiding = !hiding;
			}
		}
	}

	public void Faint () {
		if (!hiding) {
			fade.FadeIn ();
			canMove = false;
		}
	}

	void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info) {}
}
