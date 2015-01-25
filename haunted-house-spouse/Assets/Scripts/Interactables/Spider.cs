using UnityEngine;
using System.Collections;

public class Spider : Interactable {

	public float yMax;
	public float yMin;
	bool moving = false;

	void Awake () {
		Visible = true;
		Content = "ugh this is JUST crazy!! it's a SPIDER";
		Options = new string[] { "go up", "go down" };
	}

	void GoUp () {
		StartCoroutine (CoMove (Random.Range (transform.position.y, yMax)));
	}

	void GoDown () {
		StartCoroutine (CoMove (Random.Range (transform.position.y, yMin)));
	}

	IEnumerator CoMove (float yEnd) {

		moving = true;

		float time = 0.5f;
		float eTime = 0f;
		Vector3 startPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 endPosition = new Vector3 (transform.position.x, yEnd, transform.position.z);

		while (eTime < time) {
			eTime += Time.deltaTime;
			transform.position = Vector3.Lerp (startPosition, endPosition, Mathf.SmoothStep (0f, 1f, eTime / time));
			yield return null;
		}

		moving = false;
	}

	[RPC] void ReceiveContent (string newContent) {
		if (newContent == "go up") {
			GoUp ();
		}
		if (newContent == "go down") {
			GoDown ();
		}
	}
}
