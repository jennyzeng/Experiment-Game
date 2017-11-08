using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour {
	private UnityAction listener;
	Rigidbody2D rigid;

	void Awake()
	{
		listener = new UnityAction (TestFunction);
		rigid = GetComponent<Rigidbody2D>();
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
		rigid.AddForce(Vector2.right, ForceMode2D.Impulse);
	}
}
