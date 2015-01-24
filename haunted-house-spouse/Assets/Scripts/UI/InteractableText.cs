using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableText : MonoBehaviour {

	public Text text;
	public string Content {
		get { return text.text; }
		set { text.text = value; }
	}

	public static InteractableText instance = null;

	void Awake () {
		if (instance == null)
			instance = this;
	}
}
