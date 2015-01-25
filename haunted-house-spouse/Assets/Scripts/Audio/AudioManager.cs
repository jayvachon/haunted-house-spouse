using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (AudioSource))]
public class AudioManager : MonoBehaviour {

	public AudioClip[] clips;
	List<AudioSource> sources = new List<AudioSource> ();
	public static AudioManager instance = null;

	void Awake () {
		if (instance == null)
			instance = this;
		sources.Add (GetComponent<AudioSource> ());
	}

	/*void Update () {
		if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W)) {
			Loop ("footsteps_walk_carpet_3");
		} else {
			if (Input.GetKeyUp (KeyCode.Q) || Input.GetKeyUp (KeyCode.W)) {
				Stop ("footsteps_walk_carpet_3");
			}
		}
	}*/

	public void Play (AudioClip clip) {
		clips = ExtensionMethods.AppendArray (clips, clip);
		AudioSource source = GetSource (name);
		if (!source.isPlaying) {
			source.clip = clip;
			source.Play ();
		}
	}

	public void Play (string name) {
		AudioSource source = GetSource (name);
		if (!source.isPlaying) {
			source.clip = GetClip (name);
			source.Play ();
		}
	}

	public void Loop (string name) {
		AudioSource source = GetSource (name);
		if (!source.isPlaying) {
			source.clip = GetClip (name);
			source.loop = true;
			source.Play ();
		}
	}

	public void Stop (string name) {
		AudioSource source = GetPlayingSource (name);
		source.Stop ();
	}

	AudioClip GetClip (string name) {
		for (int i = 0; i < clips.Length; i ++) {
			if (clips[i].name == name)
				return clips[i];
		}
		Debug.LogError (string.Format ("No Audio Clip named {0} exists", name));
		return null;
	}

	AudioSource GetSource (string clipName) {
		foreach (AudioSource source in sources) {
			if (!source.isPlaying || source.clip.name == clipName) 
				return source;
		}
		AudioSource newSource = gameObject.AddComponent<AudioSource> ();
		sources.Add (newSource);
		return newSource;
	}

	AudioSource GetPlayingSource (string clipName) {
		foreach (AudioSource source in sources) {
			if (source.clip.name == clipName)
				return source;
		}
		return null;
	}
}
