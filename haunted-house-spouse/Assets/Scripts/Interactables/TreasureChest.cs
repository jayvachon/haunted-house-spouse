using UnityEngine;
using System.Collections;

public class TreasureChest : Interactable {

	public JumpScareImage jumpScare;

	void Awake () {
		Visible = true;
		Content = "oh wow its a freakin treasure chest";
		Options = new string[] { "jump scare" };
	}

	protected override void OnInteract () {
		if (Content == "jump scare") {
			jumpScare.Show ();
		} else {
			SetText (Content);
		}
	}

	[RPC] void ReceiveContent (string newContent) {
		Content = newContent;
	}
}
