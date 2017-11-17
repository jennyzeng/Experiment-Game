using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiJump : PlayerAbility
{
    public float jumpVelocity;
    // public KeyCode controlKey = KeyCode.Space;
    // public string axis="Jump";

	public int maxJumpTime=2; // how many times can the player jump
	private int curJumpTime=0;

	// PlayerStates playerStates;


    protected override void Start()
    {
        base.Start();
        curJumpTime = 0;
        // playerStates = GetComponent<PlayerStates>();
    }
    public override void Action()
    {
        if (rigid.velocity.y == 0)
		{
			curJumpTime = 0;
		}

        if (curJumpTime < maxJumpTime && Input.GetButtonDown(axis))
        {
			curJumpTime += 1;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
            animator.SetTrigger("Jump");
        }
    }
    protected override void DataConfig(ConfigDataSkill configData)
    {
        maxJumpTime = configData.consecutiveTimes;
    }
}
