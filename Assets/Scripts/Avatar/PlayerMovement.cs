using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float maxSpeed = 10f;
	public bool facingRight = true;
	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight)) Flip();
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
