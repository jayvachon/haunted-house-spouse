using UnityEngine;
using System.Collections;

public class Chair : Interactable {

	void Awake () {
		Content = "sure wish my friend was here so we could sit in these chairs together. Wow!!";
	}

	public override void GhostClick () {}
}
