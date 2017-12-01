using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoute : MonoBehaviour {
	public List<Transform> route;
	public float speed =1f;
	protected int curTowardPoint;
	protected int _offset;

	// Use this for initialization
	protected virtual void Start () {
		curTowardPoint = 1;
		_offset = 1;
		transform.position = route[0].position;
	}
	
	protected void FixedUpdate()
	{
		if ( Vector3.Distance(transform.position,route[curTowardPoint].position) < Time.deltaTime)
		{
			if (curTowardPoint== route.Count-1 || curTowardPoint == 0){
				_offset = -_offset;
			}
			curTowardPoint += _offset;
		}
		MoveToRoute();
	}
	protected virtual void MoveToRoute(){
		transform.position = Vector3.Lerp(transform.position, route[curTowardPoint].position, Time.deltaTime*speed);
	}
}
