using UnityEngine;
using System.Collections;

public class HideSpot : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Player player = other.gameObject.GetScript<Player> ();
		if (player != null) {
			player.CanHide = true;
		}
	}

	void OnTriggerExit (Collider other){
		Player player = other.gameObject.GetScript<Player> ();
		if (player != null) {
			player.CanHide = false;
		}
	}
}
