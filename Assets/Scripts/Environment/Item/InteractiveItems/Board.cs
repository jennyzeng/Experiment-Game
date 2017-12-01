using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : FollowRoute {

	Rigidbody2D rigid;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		rigid = GetComponent<Rigidbody2D>();
	}
	
	protected override void MoveToRoute(){
		rigid.MovePosition(Vector3.Lerp(transform.position, route[curTowardPoint].position, Time.deltaTime*speed));
		
	}
}
