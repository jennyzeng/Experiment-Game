using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAI : BaseAI
{
    public float EnemySpeed = 500;
    public bool  moveRight = true;
    private float startPos;
    private float endPos;
    

    //private float goBackPos;

    protected override void GoToNextPoint(Vector2 nextPoint)
    {
        RunTowardPoint(nextPoint);
    }

    void RunTowardPoint(Vector2 targetPoint)
    {
        playerTransform = GameObjectManager.Instance.playerTransform;
        startPos = transform.position.x;
        endPos = targetPoint.x - transform.position.x;

        if (rigid.position.x >= startPos)
        {
            moveRight = true;
        }

        if (rigid.position.x >= endPos)
        {
            moveRight = false;
        }

        if (Vector2.Distance(playerTransform.transform.position, rigid.transform.position) == 0)
        {
            moveRight = false;
            rigid.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);

        }


        if (moveRight)
        {
            if (facingRight) Flip();
            rigid.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);

        }
        if (!moveRight)
        {
            rigid.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime * 2);
            if (!facingRight) Flip();

        }
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
