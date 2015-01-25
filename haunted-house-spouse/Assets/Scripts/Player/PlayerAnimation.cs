using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public Light flashlight;
	public Light playerlight;
	public Light flashlight2;
	bool facingRight = true;

	Animator anim; 

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () 
	{
				float move = Input.GetAxis ("Horizontal");

				anim.SetFloat ("Speed", Mathf.Abs (move));

				rigidbody.velocity = new Vector2 (move * maxSpeed, rigidbody.velocity.y);
		
				if (move > 0 && !facingRight)
						Flip ();
				else if (move < 0 && facingRight)
						Flip ();

				if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow)) {
						AudioManager.instance.Loop ("footsteps"); 
				}
				if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
						AudioManager.instance.Stop ("footsteps");
				}
		}
	void Flip()
	{ 
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		if (facingRight) {
			flashlight.transform.localEulerAngles = new Vector3 (flashlight.transform.localEulerAngles.x, 74, flashlight.transform.localEulerAngles.z);
		} else {
			flashlight.transform.localEulerAngles = new Vector3 (flashlight.transform.localEulerAngles.x, -74, flashlight.transform.localEulerAngles.z);
		}

		if (facingRight) {
			playerlight.transform.localEulerAngles = new Vector3 (playerlight.transform.localEulerAngles.x, 13, playerlight.transform.localEulerAngles.z);
		} else {
			playerlight.transform.localEulerAngles = new Vector3 (playerlight.transform.localEulerAngles.x, -13, playerlight.transform.localEulerAngles.z);
		}

		if (facingRight) {
			flashlight2.transform.localEulerAngles = new Vector3 (flashlight2.transform.localEulerAngles.x, 54, flashlight2.transform.localEulerAngles.z);
		} else {
			flashlight2.transform.localEulerAngles = new Vector3 (flashlight2.transform.localEulerAngles.x, -54, flashlight2.transform.localEulerAngles.z);
		}

	}
}