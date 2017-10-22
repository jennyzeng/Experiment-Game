using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public CollisionStates collisionStates;

	void Start()
	{
		collisionStates = new CollisionStates();
	}
    void OnCollisionEnter2D(Collision2D other)
    {
       collisionStates.AddCollisionForStates(other, this.GetComponent<Collider2D>());
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        collisionStates.RemoveCollisionFromStates(collision);
    }
}
