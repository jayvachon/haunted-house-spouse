using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis ("Horizontal");
		
		rigidbody2D.velocity = new Vector2(move * maxspeed, ridgidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	
	void Flip()
	{ 
		facingright = !facingRight;
		Vector3 theScale = Transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}