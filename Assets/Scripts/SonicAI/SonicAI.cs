using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAI : BaseAI
{
    public float EnemySpeed = 500;
    public bool  moveRight = true;
    private float startPos;
    private float endPos;
    //public bool isFacingRight;

    protected override void GoToNextPoint(Vector2 nextPoint)
    {
        RunTowardPoint(nextPoint);
    }

    void RunTowardPoint(Vector2 targetPoint)
    {
        //float time;
        startPos = transform.position.x;
        endPos = targetPoint.x - transform.position.x;
        //isFacingRight = transform.localScale.x > 0;
        //Vector2 finalVelocity = CalculateRunSpeed(targetPoint, out time);
        //if ((targetPoint.x < 0 && facingRight) || (targetPoint.x < 0 && !facingRight)) Flip();
        if (moveRight)
        {
            rigid.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);
            if (targetPoint.x < 0 && facingRight)
                Flip();
        }

        if (rigid.position.x >= endPos)
            moveRight = false;

        if (!moveRight)
        {
            rigid.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime * 10);
            if (targetPoint.x < 0 && !facingRight)
                Flip();
        }
        if (rigid.position.x <= startPos)
            moveRight = true;

        //rigid.velocity = finalVelocity;
        //anim.speed = 1 / (time * 2);
        //anim.SetTrigger("Run");
    }

   

    protected override bool NeedCommand()
    {
        return rigid.velocity.x == 0;
    }

    protected override bool ShouldUpdateNextPoint()
    {
        return true;
    }

}
