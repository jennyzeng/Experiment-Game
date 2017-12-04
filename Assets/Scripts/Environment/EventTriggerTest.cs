using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour {

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("collided");
		if (other.gameObject.layer == (LayerMask.NameToLayer("Bullets")))
		{
			Debug.Log ("triggered");
			EventManager.TriggerEvent("Door");
		}
	}
}
