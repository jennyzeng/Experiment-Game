using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

 */
public class PlayerMovement : PlayerAbility {
	public float maxSpeed = 10f;
	public bool facingRight = true;
	public string axis = "Horizontal";

    public override void Action()
    {
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

    public override void Initialize()
    {
        GameManager.Instance.GetManager<InputManager>().RegisterAction(axis, Action);
    }

	/// <summary>
	/// This function is called when the MonoBehaviour will be destroyed.
	/// </summary>
	void OnDestroy()
	{
		GameManager.Instance.GetManager<InputManager>().UnregisterAction(axis);
	}

    // void FixedUpdate () {
	// 	float move = Input.GetAxis("Horizontal");
	// 	if (move != 0)
	// 	{
	// 		animator.SetBool("IsRunning", true);
	// 	}
	// 	else
	// 	{
	// 		animator.SetBool("IsRunning", false);
	// 	}

	// 	rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

	// 	if ((move > 0 && !facingRight) || (move < 0 && facingRight)) Flip();
	// }
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
