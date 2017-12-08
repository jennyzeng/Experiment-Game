using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour {
	public List<Transform> route;
	// private int curIdx;
	// private Transform curPos;
	// private int offset=1;

	// void Start()
	// {
	// 	if (route.Count==0) 
	// 	{
	// 		Debug.LogError("Route "+ gameObject.name +" requires at least one point");
	// 	}
	// 	offset = 1;
	// 	curIdx = route.Count-1;
	// 	curPos = route[curIdx];
	// }
	// public Transform Next()
	// {
	// 	if ((curIdx==route.Count-1 && offset==1)|| (curIdx == 0 && offset == -1))
	// 	{
	// 		offset = -offset;
	// 	}
	// 	curIdx += offset;
	// 	curPos = route[curIdx];
	// 	return curPos;
	// }

	// public Transform Cur()
	// {
	// 	return curPos;
	// }
}
