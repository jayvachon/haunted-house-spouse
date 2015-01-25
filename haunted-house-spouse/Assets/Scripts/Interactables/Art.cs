using UnityEngine;
using System.Collections;

public class Art : Interactable {

	void Awake () {
		Content = "my family's so cute ;) now wheres my friend ugh??";
	}

	public override void GhostClick () {}
}
