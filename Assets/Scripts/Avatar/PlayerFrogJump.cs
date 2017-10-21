using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogJump : MonoBehaviour {

	// Use this for initialization
	public float maxJumpVelocity;
	public float addAmountEachTime;
	public float sensitivity;
	float pastTime;
	float curVelocity;
	bool isPreparing;
	Rigidbody2D rigid;
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		isPreparing = false;
	}
	

	void Update () {
		if (rigid.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space))
		{
			if (!isPreparing)
			{
				isPreparing = true;
				pastTime = Time.time;
				curVelocity = addAmountEachTime;
			}
		}
		if (Input.GetKey(KeyCode.Space) && Time.time-pastTime >= sensitivity)
			{
				curVelocity += addAmountEachTime;
				if (curVelocity > maxJumpVelocity) curVelocity = maxJumpVelocity;
				pastTime = Time.time;
			}
		if (rigid.velocity.y == 0 && isPreparing && Input.GetKeyUp(KeyCode.Space))
		{
			isPreparing = false;
			rigid.velocity = new Vector2(rigid.velocity.x, curVelocity);
		}
	}
}
