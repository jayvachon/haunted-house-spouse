using UnityEngine;
using System.Collections;

public class Note : Interactable {

	protected override void OnInteract () {
		Debug.Log ("heard");
	}
}
