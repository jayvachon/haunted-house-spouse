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

	void Update () {
		/*if (Input.GetKeyDown (KeyCode.Space)) {
			Loop ("jumpscare");
		}*/
	}

	public void Play (AudioClip clip) {
		clips = ExtensionMethods.AppendArray (clips, clip);
		AudioSource source = GetSource ();
		source.clip = clip;
		source.Play ();
	}

	public void Play (string name) {
		AudioSource source = GetSource ();
		source.clip = GetClip (name);
		source.Play ();
	}

	public void Loop (string name) {
		AudioSource source = GetSource ();
		source.clip = GetClip (name);
		source.loop = true;
		source.Play ();
	}

	AudioClip GetClip (string name) {
		for (int i = 0; i < clips.Length; i ++) {
			if (clips[i].name == name)
				return clips[i];
		}
		Debug.LogError (string.Format ("No Audio Clip named {0} exists", name));
		return null;
	}

	AudioSource GetSource () {
		foreach (AudioSource source in sources) {
			if (!source.isPlaying) 
				return source;
		}
		AudioSource newSource = gameObject.AddComponent<AudioSource> ();
		sources.Add (newSource);
		return newSource;
	}
}
