using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float disappearTime=5f;
	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(gameObject);
	}
	

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
