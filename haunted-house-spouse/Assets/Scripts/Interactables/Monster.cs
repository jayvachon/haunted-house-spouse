using UnityEngine;
using System.Collections;

public class Monster : Interactable {

	void Awake () {
		if (NetworkManager.Ghost) {
			Visible = true;
		} else {
			Visible = false;
		}
		Options = new string[] {"APPEAR!"};
	}

	[RPC] void ReceiveContent (string newContent) {
		if (newContent == "APPEAR!") {
			
		}
	}
}
