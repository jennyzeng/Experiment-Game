using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathTools {

	public static void Flip(Transform transform)
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public static bool IsOnLeft(Vector3 curPoint, Vector3 relatePoint)
	{
		return curPoint.x > relatePoint.x;
	}
}
