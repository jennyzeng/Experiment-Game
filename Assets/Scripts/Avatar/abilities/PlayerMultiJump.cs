using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiJump : PlayerAbility
{
    public float jumpVelocity;
    public KeyCode controlKey = KeyCode.Space;
    public string axis="Jump";

	public int maxJumpTime=2; // how many times can the player jump
	private int curJumpTime=0;
	PlayerStates playerStates;

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

    protected override void Start()
    {
        base.Start();
        curJumpTime = 0;
        playerStates = GetComponent<PlayerStates>();
    }
    public override void Action()
    {
        if (rigid.velocity.y == 0)
		{
			curJumpTime = 0;
		}

        if (curJumpTime < maxJumpTime && Input.GetKeyDown(controlKey))
        {
			curJumpTime += 1;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
            animator.SetTrigger("Jump");
        }
    }

}
