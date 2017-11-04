using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : BaseAI {
	public float maxSpeed = 3f; //max x speed
    public float maxJumpDistance = 5f;
    bool updateNextPoint=true;
    protected override void GoToNextPoint(Vector2 nextPoint)
    {
        JumpTowardPoint(nextPoint);
    }

	void JumpTowardPoint(Vector2 targetPoint)
    {
        float time;
		Vector2 finalVelocity = CalculateJumpSpeed(targetPoint, out time);
        if ((finalVelocity.x < 0 && facingRight) || (finalVelocity.x > 0 && !facingRight) ) Flip();
        rigid.velocity = finalVelocity;
        anim.speed = 1/(time*2);
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
        return rigid.velocity.y == 0 ;
    }

    protected override bool ShouldUpdateNextPoint()
    {
        return true;
    }

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			coll.gameObject.SendMessage("TakeDamage", 1);

	}

}
