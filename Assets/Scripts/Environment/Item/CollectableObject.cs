using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			OnBeingPickedUp(other);
		}
	}
	protected abstract void OnBeingPickedUp(Collider2D player);

}
