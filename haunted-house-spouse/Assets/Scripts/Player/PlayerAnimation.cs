using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public Fade fade;

	bool canHide = false;
	public bool CanHide {
		get { return canHide; }
		set { canHide = value; }
	}

	bool hiding = false;
	bool canMove = true;

	public float maxSpeed = 10f;
	public GameLight flashlight;
	public GameLight playerlight;
	public GameLight flashlight2;
	bool facingRight = true;

	Animator anim; 

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () 
	{	
		if (NetworkManager.Ghost) return;

		if (!hiding && canMove) {
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move));
			rigidbody.velocity = new Vector2 (move * maxSpeed, rigidbody.velocity.y);

			if (move > 0 && !facingRight)
					Flip ();
			else if (move < 0 && facingRight)
					Flip ();

			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
					AudioManager.instance.Loop ("footsteps"); 
			} else {
				if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
					AudioManager.instance.Stop ("footsteps");
				}
			}
		}

		if (CanHide) {
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				ToggleHide ();
				if (hiding) {
					rigidbody.velocity = Vector2.zero;
					anim.SetFloat ("Speed", 0);
					AudioManager.instance.Stop ("footsteps");
				}
			}
		}
	}

	void ToggleHide () {
		hiding = !hiding;
		if (hiding) {
			playerlight.DisableLight ();
			flashlight.DisableLight ();
			flashlight2.DisableLight ();
		} else {
			playerlight.EnableLight ();
			flashlight.EnableLight ();
			flashlight2.EnableLight ();
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

	public void Faint () {
		if (!hiding) {
			fade.FadeIn ();
			canMove = false;
		}
	}
}