using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour {
	private UnityAction listener;


	void Awake()
	{
		listener = new UnityAction (TestFunction);
	}
	void OnEnable()
	{
		EventManager.StartListening("test", listener);
	}

	void OnDisable()
	{
		EventManager.StopListening("test", listener);
	}

	void TestFunction()
	{
		Debug.Log("Test function was called");
	}
}
