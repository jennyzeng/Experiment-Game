using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : BaseAI {
	public float maxSpeed = 3f; //max x speed

	// public float jumpPower = 5f;
	public float maxJumpDistance = 3f;
    bool updateNextPoint=true;
    protected override void GoToNextPoint(Vector2 nextPoint)
    {
        if (Vector2.Distance(nextPoint, transform.position) < maxJumpDistance)
		{
            JumpTowardPoint(nextPoint);
            updateNextPoint = true;
        }
        else
        {
            // jump to the max distance point before the actual point
            Vector2 targetPoint;
            if (nextPoint.x > transform.position.x) // on the right
                targetPoint = new Vector2(transform.position.x + maxJumpDistance, nextPoint.y);
            else    // next point on the left
                targetPoint = new Vector2(transform.position.x - maxJumpDistance, nextPoint.y);
            JumpTowardPoint(targetPoint);
            updateNextPoint = false;
        }
    }

	void JumpTowardPoint(Vector2 targetPoint)
    {
        float time;
		Vector2 finalVelocity = CalculateJumpSpeed(targetPoint, out time);
        if ((finalVelocity.x < 0 && facingRight) || (finalVelocity.x > 0 && !facingRight) ) Flip();
        rigid.velocity = finalVelocity;
        anim.SetTrigger("Jump");
    }
 
    private Vector2 CalculateJumpSpeed(Vector2 targetPoint, out float time)
    {	
        float gravity = Physics.gravity.magnitude;
        float xOffset = targetPoint.x - transform.position.x;
        time = Mathf.Abs(xOffset/maxSpeed);
        if (time == 0){
            return new Vector2(0,0);
        } 

        float yOffset = targetPoint.y - transform.position.y;
        float ySpeed = (yOffset + 0.5f * gravity * time * time) / time;
        Vector2 finalVelocity;
        if (xOffset > 0)
        {
            finalVelocity = new Vector2(maxSpeed, ySpeed);
        }
        else{
            finalVelocity = new Vector2(-maxSpeed, ySpeed);
        } 
        // draw velocity line for debugging
        // Debug.DrawLine(transform.position, (Vector3)finalVelocity + transform.position, Color.red, 2);
        return finalVelocity;
    }

    protected override bool NeedCommand()
    {
        return rigid.velocity.y == 0;
    }

    protected override bool ShouldUpdateNextPoint()
    {
        return updateNextPoint;
    }

    // void FixedUpdate () {
    // 	if(player == null) player = GameManager.Instance.GetManager<GameObjectManager> ().player;
    // 	if (player == null)
    // 		return;

    // 	if (rigid.velocity.y == 0 && !grounded)
    // 		grounded = true;
    // 		// anim.SetBool ("inair", false);

    // 	if (grounded) {
    // 		grounded = false;
    // 		// anim.SetBool ("inair", true);
    // 		anim.SetTrigger ("Jump1");
    // 		float move = 1;
    // 		if (Mathf.Abs (player.transform.position.x - transform.position.x) > monitor_range) {
    // 			move = (Random.Range (0, 2) == 0) ? -1 : 1;
    // 		} else {
    // 			move = (player.transform.position.x - transform.position.x > 0) ? 1 : -1;
    // 		}

    // 		if ((move > 0 && !facingRight) || (move < 0 && facingRight)) Flip();
    // 		rigid.velocity = new Vector2(move * maxSpeed, jumpPower);
    // 	}

    // }

}
