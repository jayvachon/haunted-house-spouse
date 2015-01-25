using UnityEngine;
using System.Collections;

public class Monster : Interactable {

	public Transform player;
	float xMin = -20;
	float xMax = 20;
	float speed = 2;

	void Awake () {
		if (NetworkManager.Ghost) {
			Visible = true;
		} else {
			Visible = false;
		}
		Options = new string[] {"APPEAR!"};
	}

	void Run (bool left) {
		StartCoroutine (CoRun (left));
	}

	IEnumerator CoRun (bool left) {
		float sign = left ? -1 : 1;
		while (transform.position.x > xMin && transform.position.x < xMax) {
			transform.Translate (sign * speed * Time.deltaTime, 0, 0);
			yield return null;
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ReceiveContent ("APPEAR!");
		}
	}

	[RPC] void ReceiveContent (string newContent) {
		if (newContent == "APPEAR!") {
			if (player.position.x < transform.position.x) {
				Run (true);
			} else {
				Run (false);
			}
		}
	}
}
