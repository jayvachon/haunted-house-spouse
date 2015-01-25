using UnityEngine;
using System.Collections;

public class Note : Interactable {

	void Awake () {
		if (NetworkManager.Ghost) {
			Visible = true;
		} else {
			Visible = false;
		}
	}

	public override void GhostClick () {
		NotesMenu.instance.ShowNotes (this, new string[] {"test", "ok another ttest"});	
	}

	[RPC] void ReceiveContent (string newContent) {
		Content = newContent;
		if (newContent != "") {
			Visible = true;
		}
	}
}
