using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiJump : PlayerAbility
{
    public float jumpVelocity;
    public KeyCode controlKey = KeyCode.Space;

	public int maxJumpTime=2; // how many times can the player jump
	private int curJumpTime=0;
	public PlayerStates playerStates;

    public override void Initialize()
    {
    }

    protected override void Start()
    {
        base.Start();
        curJumpTime = 0;
        // playerStates = GetComponent<PlayerStates>();
    }
    // Update is called once per frame
    void Update()
    {
        if (curJumpTime < maxJumpTime && Input.GetKeyDown(controlKey))
        {
			curJumpTime += 1;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
        }
		if (playerStates.collisionStates.HasRightCollision() ||
             playerStates.collisionStates.HasLeftCollision())
		{
			curJumpTime = maxJumpTime;
		}
		if (rigid.velocity.y == 0 && playerStates.collisionStates.HasBottomCollision())
		{
			curJumpTime = 0;
		}
    }
}
