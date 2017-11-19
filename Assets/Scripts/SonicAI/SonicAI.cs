using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAI : BaseAI
{
    public float EnemySpeed = 500;
    public bool  moveRight = true;
    private float startPos;
    private float endPos;
    protected GameObjectManager playerPos;

    //private float goBackPos;

    protected override void GoToNextPoint(Vector2 nextPoint)
    {
        RunTowardPoint(nextPoint);
    }

    void RunTowardPoint(Vector2 targetPoint)
    {
        startPos = transform.position.x;
        endPos = targetPoint.x - transform.position.x;
        //goBackPos = playerPos.playerTransform.position.x;
        //playerPos = player.transform.position.x;
        if (rigid.position.x >= startPos)
            moveRight = true;  
        if (rigid.position.x >= endPos)
        {
            moveRight = false;
        }
        

        if (moveRight)
        {
            if (facingRight) Flip();
            rigid.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);
            //DetectPlayer();
        }
        if (!moveRight)
        {
            rigid.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime * 10);
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
