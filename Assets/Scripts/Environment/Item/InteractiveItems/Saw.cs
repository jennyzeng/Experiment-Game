using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : FollowRoute {

	public float rotationPerFrame = 10;

	protected override void MoveToRoute(){
		base.MoveToRoute();
		// Rotate the object around its local Z axis
        transform.Rotate(0,0,Time.deltaTime*rotationPerFrame*_offset);
	}
}
