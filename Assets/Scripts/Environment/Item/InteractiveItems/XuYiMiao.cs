using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuYiMiao : CollectableObject
{
	public float ResetAfterSecs = 5f;
	Collider2D collide;
	Animator anim;
	int addJumpPerTouch = 1;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		collide =GetComponent<Collider2D>();
		anim = GetComponent<Animator>();
	}
    protected override void OnBeingPickedUp(Collider2D player)
    {

		PlayerMultiJump ability= player.gameObject.GetComponentInChildren<PlayerMultiJump>();
		if (ability == null) return;
		Debug.Log("add jump");
		bool isAdded = ability.AddJumpTime(addJumpPerTouch);
		if (isAdded)
		{
			collide.enabled = false;
			anim.SetBool("IsDisappeared", true);
			TimerManager.Instance.AddTimer(ResetAfterSecs, gameObject, ResetItem);
		}
    }

	void ResetItem()
	{
		collide.enabled = true;
		anim.SetBool("IsDisappeared", false);
	}
}
