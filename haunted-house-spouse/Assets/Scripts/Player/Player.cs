using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NetworkView))]
public class Player : MonoBehaviour {

	float speed = 5f;

	void Update () {
		if (NetworkManager.Ghost) return;
		float translation = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate (translation, 0, 0);
	}

	void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info) {}
}
