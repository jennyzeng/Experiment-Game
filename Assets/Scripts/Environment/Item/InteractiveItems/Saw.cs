using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : SetDamage {

	public List<Transform> route;
	public float speed=0.5f;
	public float rotationPerFrame = 10;
	private Rigidbody2D rigid;
	private int curTowardPoint;
	private int _offset;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		rigid=GetComponent<Rigidbody2D>();
		curTowardPoint = 1;
		_offset = 1;
		transform.position = route[0].position;
	}
	void FixedUpdate()
	{
		if ( Vector3.Distance(transform.position,route[curTowardPoint].position) < Time.deltaTime)
		{
			if (curTowardPoint== route.Count-1 || curTowardPoint == 0){
				_offset = -_offset;
			}
			curTowardPoint += _offset;
		}
		transform.position = Vector3.Lerp(transform.position, route[curTowardPoint].position, Time.deltaTime*speed);
		// Rotate the object around its local Z axis
        transform.Rotate(0,0,Time.deltaTime*rotationPerFrame*_offset);
	}
}
