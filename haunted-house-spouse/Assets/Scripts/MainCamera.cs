using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform player;
	Vector3 startPosition;
	float xMin = -2;
	float xMax = 2;

	void Start () {
		startPosition = transform.position;
	}

	void Update () {
		float x = player.position.x;
		x = Mathf.Max (xMin, x);
		x = Mathf.Min (xMax, x);
		transform.position = new Vector3 (x, startPosition.y, startPosition.z);
	}
}
