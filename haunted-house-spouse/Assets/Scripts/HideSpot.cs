using UnityEngine;
using System.Collections;

public class HideSpot : Interactable {

	void Awake () {
		Content = "Press up or down to hide";
	}

	public override void GhostClick () {}

	protected override void OnTriggerEnter (Collider other) {
		base.OnTriggerEnter (other);
		PlayerAnimation player = other.gameObject.GetScript<PlayerAnimation> ();
		if (player != null) {
			player.CanHide = true;
		}
	}

	protected override void OnTriggerExit (Collider other){
		base.OnTriggerExit (other);
		PlayerAnimation player = other.gameObject.GetScript<PlayerAnimation> ();
		if (player != null) {
			player.CanHide = false;
		}
	}
}
