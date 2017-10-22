using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStates
{

    public List<GameObject> collideFromLeft;
    public List<GameObject> collideFromTop;
    public List<GameObject> collideFromRight;
    public List<GameObject> collideFromBottom;

    public CollisionStates()
    {
        Reset();
    }
    public void Reset()
    {
        collideFromLeft = new List<GameObject>();
        collideFromTop = new List<GameObject>();
        collideFromRight = new List<GameObject>();
        collideFromBottom = new List<GameObject>();
    }
	public void AddCollisionForStates(Collision2D other, Collider2D myCollider)
	{

		Collider2D collider = other.collider;
		Vector2 contactPoint = (other.contacts[0].point+other.contacts[1].point)/2;
        Vector2 center = myCollider.bounds.center;
		// foreach(ContactPoint2D contact in other.contacts)
		// {
		// 	Debug.DrawLine(contact.point, contact.point + contact.normal, Color.red, 20, false);
			
		// }
		// Debug.DrawLine(center, center + other.contacts[0].normal, Color.yellow, 20, false);
		// Debug.DrawLine(contactPoint, contactPoint + other.contacts[0].normal, Color.green, 20, false);
		// Debug.Log("center: "+ center);
		// Debug.Log("contact: "+ contactPoint);

		if (System.Math.Abs(contactPoint.y - center.y) > System.Math.Abs(contactPoint.x - center.x))
		{
			if (contactPoint.y > center.y)
			{
				collideFromTop.Add(other.gameObject);
				// Debug.Log("top");
			}
			else if (contactPoint.y < center.y)
			{
				collideFromBottom.Add(other.gameObject);
				// Debug.Log("bottom");
			}
		}
		else
		{
			if (contactPoint.x > center.x)
			{
				collideFromRight.Add(other.gameObject);
				// Debug.Log("right");
			}
			else if (contactPoint.x < center.x)
			{
				collideFromLeft.Add(other.gameObject);
				// Debug.Log("left");
			}
		}

        // Collider2D collider = other.collider;
        // float RectWidth =  myCollider.bounds.size.x;
        // float RectHeight =  myCollider.bounds.size.y;
        // // float circleRad = collider.bounds.size.x;

        // //  if(collider.name == "target")
        // //  { 
        // Vector3 contactPoint = other.contacts[0].point;
        // Vector3 center = collider.bounds.center;

        // if (contactPoint.y > center.y && //checks that circle is on top of rectangle
        //     (contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2))
        // {
		// 	Debug.Log("top");
        //     collideFromTop.Add(other.gameObject);
        // }
        // else if (contactPoint.y < center.y &&
        //     (contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2))
        // {
		// 	Debug.Log("bottom");
        //     collideFromBottom.Add(other.gameObject);
        // }
        // else if (contactPoint.x > center.x &&
        //     (contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2))
        // {
		// 	Debug.Log("right");
		// 	collideFromRight.Add(other.gameObject);
        // }
        // else if (contactPoint.x < center.x &&
        //     (contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2))
        // {
		// 	Debug.Log("left");
        //     collideFromLeft.Add(other.gameObject);
        //     //  }
        // }
	}
	public void RemoveCollisionFromStates(Collision2D collision)
	{
		GameObject collider = collision.collider.gameObject;
        if (collideFromLeft.Contains(collider)) 
            collideFromLeft.Remove(collider);
        else if (collideFromRight.Contains(collider)) 
            collideFromRight.Remove(collider);
        else if (collideFromTop.Contains(collider)) 
            collideFromTop.Remove(collider);
        else if (collideFromBottom.Contains(collider)) 
            collideFromBottom.Remove(collider);
	}
	public bool HasLeftCollision()
	{
		return collideFromLeft.Count >0;
	}
	public bool HasRightCollision()
	{
		return collideFromRight.Count >0;
	}
	public bool HasTopCollision()
	{
		return collideFromTop.Count >0;
	}
	public bool HasBottomCollision()
	{
		return collideFromBottom.Count >0;
	}
}
