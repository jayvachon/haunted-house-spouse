using UnityEngine;
using System.Collections;

public class Portrait : Interactable {

	void Awake () {
		Content = "we always had such great '''art''' taste aww";
	}

	public override void GhostClick () {}
}
