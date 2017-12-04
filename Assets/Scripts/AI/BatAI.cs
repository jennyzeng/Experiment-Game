using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class BatAI : BaseAI {

	public float speed= 4f;
	public float shootSpeed=100f;
	public Rigidbody2D ballPrefab;
	public int numPerRow=4;
	public int rowCount = 1;

	private delegate void AttackModeDelegate(Vector2 nextPoint);
	private AttackModeDelegate AttackModeHandler;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	protected override void Start()
	{
		base.Start();
		AttackModeHandler = FlyFast;
	}
    protected override void GoToNextPoint(Vector2 nextPoint)
    {
		if ((facingRight && MathTools.IsOnLeft(transform.position, nextPoint)) || (
			!facingRight && !MathTools.IsOnLeft(transform.position, nextPoint
		)))
		{
			MathTools.Flip(transform);
			facingRight = !facingRight;
		}
        FlyFast(nextPoint);
    }

    protected override bool NeedCommand()
    {
        return true;
    }

    protected override bool ShouldUpdateNextPoint()
    {
		bool answer = Vector2.Distance(transform.position, nextTargetPoint) < Time.deltaTime;
		if (answer)
		{
			ShootBall();
		}
		return answer;
    }

	void FlyFast(Vector2 nextPoint){
		transform.position = Vector3.Lerp(transform.position, nextPoint, speed*Time.deltaTime);
	}

	void ShootBall()
	{
		for (int i=1; i <= rowCount; i++)
		{
			for (int j=0; j<numPerRow; j++)
			{
				Rigidbody2D ball = Instantiate(ballPrefab, transform.position, transform.rotation);
				float angle = 2f * Mathf.PI / (float)numPerRow * j;
				Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
				ball.AddForce(direction*shootSpeed*i);
			}
			
		}

	}

}
