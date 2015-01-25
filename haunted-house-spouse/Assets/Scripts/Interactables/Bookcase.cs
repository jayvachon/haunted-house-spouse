using UnityEngine;
using System.Collections;

public class Bookcase : Interactable {

	void Awake () {
		Content = "if these books were food i would eat 'em :P";
	}

	public override void GhostClick () {}
}
