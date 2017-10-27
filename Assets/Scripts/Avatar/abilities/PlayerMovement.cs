using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

 */
public class PlayerMovement : PlayerAbility {
	public float maxSpeed = 10f;
	public bool facingRight = true;
	// public string axis = "Horizontal";

    public override void Action()
    {
        float move = Input.GetAxis("Horizontal");
		if (move != 0)
		{
			animator.SetBool("IsRunning", true);
		}

		rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight)) Flip();
    }

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{ // had to add this to correct the animation
		if (animator.GetBool("IsRunning") && Input.GetAxis("Horizontal") == 0) 
			animator.SetBool("IsRunning", false);
	}


    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
