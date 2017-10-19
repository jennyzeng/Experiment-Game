using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
single jump implementation
 */
public class PlayerJump : MonoBehaviour {
	float jumpForce;
	Rigidbody2D rigid;
	Animator animator;
	// Use this for initialization
	void Start () {
		
		rigid = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float jump = Input.GetAxis("Jump");
		if(jump>0)
		{
			rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}
}
