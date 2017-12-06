using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BehaviorOnPoint(Transform point);
public class StageBehavior : MonoBehaviour {
	// the behavior in one stage

	public List<Transform> route;
	public List< BehaviorOnPoint> behaviors;
	private int curIdx;
	private int offset=1;
	private KeyValuePair<Transform, BehaviorOnPoint> curPair;
	void Start()
	{
		if (route.Count==0) 
		{
			Debug.LogError("Route "+ gameObject.name +" requires at least one point");
		}
		offset = 1;
		curIdx = 0;
		// curPair = new KeyValuePair<Transform, BehaviorOnPoint>(route[curIdx], behaviors[curIdx]);
	}

	public void SetBehaviors(List< BehaviorOnPoint> behaviors)
	{
		this.behaviors = behaviors;
	}
	public KeyValuePair<Transform, BehaviorOnPoint> Next()
	{
		if ( (curIdx==route.Count-1 && offset==1)|| (curIdx == 0 && offset == -1))
		{
			offset = -offset;
		}
		curIdx += offset;
		curPair = new KeyValuePair<Transform, BehaviorOnPoint>(route[curIdx], behaviors[curIdx]);
		return curPair;
	}

	public KeyValuePair<Transform, BehaviorOnPoint> Cur()
	{
		if (curPair.Key == null) {
			curPair = new KeyValuePair<Transform, BehaviorOnPoint>(route[curIdx], behaviors[curIdx]);
		}
			return curPair;
	}
	
}
