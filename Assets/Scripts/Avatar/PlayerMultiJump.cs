using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiJump : MonoBehaviour
{
    public float jumpVelocity;
    public KeyCode controlKey = KeyCode.Space;

	public int maxJumpTime=2; // how many times can the player jump
	private int curJumpTime=0;
    Rigidbody2D rigid;
    Animator animator;

    // Use this for initialization
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		curJumpTime = 0;
    }

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		if (rigid.velocity.y != 0)
		{
			curJumpTime = maxJumpTime-1;
			// rigid.velocity = new Vector2(0,rigid.mass*5);
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (curJumpTime < maxJumpTime && Input.GetKeyDown(controlKey))
        {
			curJumpTime += 1;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
        }
		if (rigid.velocity.y == 0)
		{
			curJumpTime = 0;
		}
    }
}
