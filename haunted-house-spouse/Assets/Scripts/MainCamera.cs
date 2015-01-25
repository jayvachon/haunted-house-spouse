using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform player;
	Vector3 startPosition;
	public float xMin = -2;
	public float xMax = 2;
	bool ghost = false;

	void Awake () {
		startPosition = transform.position;
		if (NetworkManager.Ghost) {
			camera.orthographicSize = 5;
			startPosition.y = 0;
			ghost = true;
		} else {
			camera.orthographicSize = 3;
			startPosition.y = -0.8f;
		}
	}

	void Update () {
		float x = player.position.x;
		if (ghost) x += 5.5f;
		x = Mathf.Max (xMin, x);
		x = Mathf.Min (xMax, x);
		transform.position = new Vector3 (x, startPosition.y, startPosition.z);
	}
}
