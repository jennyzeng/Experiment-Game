using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
single jump implementation
 */
public class PlayerJump : MonoBehaviour {
	public float jumpVelocity;
	Rigidbody2D rigid;
	Animator animator;
	// Use this for initialization
	void Start () {
		
		rigid = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		bool jump = Input.GetKeyUp(KeyCode.Space);
		Debug.Log(jump);
		if(jump && rigid.velocity.y == 0)
		{
			rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
		}
	}
}
