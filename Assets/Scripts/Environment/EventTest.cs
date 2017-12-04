using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour {
	private UnityAction listener;
	Rigidbody2D rigid;

	float t;
	Vector3 startPosition;
	Vector3 target;
	float timeToReachTarget;
	bool triggered;

	void Awake ()
	{
		startPosition = target = transform.position;
		listener = new UnityAction (TestFunction);
		rigid = GetComponent<Rigidbody2D>();
	}
	void OnEnable()
	{
		EventManager.StartListening("Door", listener);
	}

	void OnDisable()
	{
		EventManager.StopListening("Door", listener);
	}

	void TestFunction()
	{
		target.y = -10;
		Vector3 result = target;
		triggered = true;
		SetDestination (result, 2);
	}

	void Update() 
	{
		if(triggered){
			t += Time.deltaTime/timeToReachTarget;
			transform.position = Vector3.Lerp(startPosition, target, t);
			if (transform.position == target)
				triggered = false;
		}
	}
	public void SetDestination(Vector3 destination, float time)
	{
		t = 0;
		startPosition = transform.position;
		timeToReachTarget = time;
		target = destination; 
	}


}
