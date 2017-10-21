using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
single jump implementation
 */
public class PlayerJump : MonoBehaviour {
	public float jumpVelocity;
	public KeyCode controlKey=KeyCode.Space;

	[Tooltip("when distance to the ground is <= jumpAccuracy and >= -jumpAccuracy, player can jump again")]
	public float jumpAccuracy = 0.01f; 
	Rigidbody2D rigid;
	Animator animator;
	
	// Use this for initialization
	void Start () {
		
		rigid = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(controlKey) && rigid.velocity.y <= jumpAccuracy  && rigid.velocity.y >= -jumpAccuracy)
		{
			rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
		}
	}
}
