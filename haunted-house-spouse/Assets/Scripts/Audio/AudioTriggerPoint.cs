using UnityEngine;
using System.Collections;

public class AudioTriggerPoint : MonoBehaviour {

	public AudioClip clip;
	public string colliderName = "Player";
	bool played = false;

	void OnTriggerEnter (Collider other) {
		if (played) return;
		if (other.name == colliderName) {
			AudioManager.instance.Play (clip);
			played = true;
		}
	}
}
