using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiJump : PlayerAbility
{
    public float jumpVelocity;
    public KeyCode controlKey = KeyCode.Space;

	public int maxJumpTime=2; // how many times can the player jump
	private int curJumpTime=0;

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    protected override void Start()
    {
		base.Start();
		curJumpTime = 0;
    }
	

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		// if (rigid.velocity.y != 0)
		// {
			ContactPoint contact = other.contacts[0];
			if (contact.point.x == transform.position.x)
			{//hit ground
				curJumpTime = 0;
			}
			else
			{
				curJumpTime = maxJumpTime-1;
				rigid.velocity = new Vector2(0,rigid.mass*5);
			}
			
			

			// rigid.velocity = new Vector2(0,rigid.mass*5);
		// }
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
