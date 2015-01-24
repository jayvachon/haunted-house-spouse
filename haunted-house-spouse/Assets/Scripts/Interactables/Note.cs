using UnityEngine;
using System.Collections;

public class Note : Interactable {

	string content = "";
	public string Content {
		get { return content; }
		set { content = value; }
	}

	protected override void OnInteract () {
		SetText (Content);
	}

	public override void Click (bool left) {
		//if (!NetworkManager.Ghost) return;
		if (left) {
			NotesMenu.instance.ShowNotes (this, new string[] {"test", "ok another ttest"});	
		}
	}
}
