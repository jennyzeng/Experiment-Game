using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterativeItem : MonoBehaviour {

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	protected virtual void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			InteractAction(other);
		}
	}
	protected abstract void InteractAction(Collision2D player);

}
