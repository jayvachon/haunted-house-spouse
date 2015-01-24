using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float speed = 5f;

	void Update () {
		float translation = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate (translation, 0, 0);
	}
}
