using UnityEngine;
using System.Collections;

public class NotesMenu : MonoBehaviour {

	bool show = false;
	Note selectedNote = null;
	string[] notes = new string[] {
		"note blaha ahbl blah ahlag",
		"here's another note for ya congratulations",
		"note 3",
		"note 4",
		"note 5",
	};

	public static NotesMenu instance = null;

	void Awake () {
		if (instance == null)
			instance = this;
	}

	public void ShowNotes (Note selectedNote, string[] notes) {
		this.selectedNote = selectedNote;
		this.notes = notes;
		show = true;
	}

	void OnGUI () {
		if (!show) return;
		for (int i = 0; i < notes.Length; i ++) {
			string content = notes[i];
			if (GUILayout.Button ("the note reads: " + content, GUILayout.Width (300), GUILayout.Height (75))) {
				selectedNote.SendContent (content);
				selectedNote.NoteSet = true;
				show = false;
			}
		}
	}
}
