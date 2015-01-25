using UnityEngine;
using System.Collections;

public class HideSpot : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		PlayerAnimation player = other.gameObject.GetScript<PlayerAnimation> ();
		if (player != null) {
			player.CanHide = true;
		}
	}

	void OnTriggerExit (Collider other){
		PlayerAnimation player = other.gameObject.GetScript<PlayerAnimation> ();
		if (player != null) {
			player.CanHide = false;
		}
	}
}
