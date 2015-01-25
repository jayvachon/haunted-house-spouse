using UnityEngine;
using System.Collections;

public class Note : Interactable {

	public string[] notes;
	bool noteSet = false;
	public bool NoteSet {
		set { noteSet = value; }
	}

	void Awake () {
		if (NetworkManager.Ghost) {
			Visible = true;
		} else {
			Visible = false;
		}
	}

	public override void GhostClick () {
		if (!noteSet) {
			NotesMenu.instance.ShowNotes (this, notes);	
		}
	}

	[RPC] void ReceiveContent (string newContent) {
		Content = newContent;
		if (newContent != "") {
			Visible = true;
		}
	}
}
