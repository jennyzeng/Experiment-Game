﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogJump : PlayerAbility
{

    // Use this for initialization
    public float maxJumpVelocity;
    public float addAmountEachTime;
    public float sensitivity;
    // public KeyCode controlKey = KeyCode.Space;
    // public string axis = "Jump";
    public Animator preparingEffectAnim;
    float pastTime;
    float curVelocity;
    bool isPreparing;

    public override void Action()
    {
        if (!isPreparing && rigid.velocity.y == 0 && Input.GetButtonDown(axis))
        {// prepare
            isPreparing = true;
            preparingEffectAnim.gameObject.SetActive(true);
            preparingEffectAnim.SetBool("blueFire", true);
            pastTime = Time.time;
            curVelocity = addAmountEachTime;
        }
        if (isPreparing && Input.GetButton(axis) && Time.time - pastTime >= sensitivity)
        {// add amount
            curVelocity += addAmountEachTime;
            if (curVelocity > maxJumpVelocity) curVelocity = maxJumpVelocity;
            pastTime = Time.time;
        }
        if (isPreparing && Input.GetButtonUp(axis))
        {// jump
            isPreparing = false;
            rigid.velocity = new Vector2(rigid.velocity.x, curVelocity);
            curVelocity = addAmountEachTime;
            preparingEffectAnim.SetBool("blueFire", false);
            preparingEffectAnim.gameObject.SetActive(false);

        }
    }

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    protected override void Start()
    {
        base.Start();
        isPreparing = false;
        preparingEffectAnim.SetBool("blueFire", false);
        preparingEffectAnim.gameObject.SetActive(false);
    }
}
