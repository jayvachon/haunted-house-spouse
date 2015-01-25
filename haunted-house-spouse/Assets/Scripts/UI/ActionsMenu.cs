using UnityEngine;
using System.Collections;

public class ActionsMenu : MonoBehaviour {

	bool show = false;
	Interactable selectedInteractable = null;
	string[] options = new string[0];

	public static ActionsMenu instance = null;

	void Awake () {
		if (instance == null)
			instance = this;
	}

	public void ShowOptions (Interactable selectedInteractable, string[] options) {
		this.selectedInteractable = selectedInteractable;
		this.options = options;
		show = true;
	}

	void OnGUI () {
		if (!show) return;
		for (int i = 0; i < options.Length; i ++) {
			string content = options[i];
			if (GUILayout.Button (content)) {
				selectedInteractable.SendContent (content);
				show = false;
			}
		}
	}
}