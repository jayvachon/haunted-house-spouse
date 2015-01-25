using UnityEngine;
using System.Collections;

public class GameLight : MonoBehaviour {

	Light light;

	void Awake () {
		light = GetComponent<Light>();
	}

	public void DisableLight () {
		light.enabled = false;
	}

	public void EnableLight () {
		light.enabled = true;
	}
}
