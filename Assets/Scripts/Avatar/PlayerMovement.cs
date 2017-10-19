using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

 */
public class PlayerMovement : MonoBehaviour {
	public float maxSpeed = 10f;
	public bool facingRight = true;
	Rigidbody2D rigid;
	Animator animator;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		if (move != 0)
		{
			animator.SetBool("IsRunning", true);
		}
		else
		{
			animator.SetBool("IsRunning", false);
		}

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
