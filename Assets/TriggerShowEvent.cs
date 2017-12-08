using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerShowEvent : MonoBehaviour {
	private UnityAction listener;
	Rigidbody2D rigid;


	void Awake ()
	{
		listener = new UnityAction (TestFunction);
		EventManager.StartListening("Trigger", listener);
		rigid = GetComponent<Rigidbody2D>();
		gameObject.SetActive (false);
	}
	void OnEnable()
	{
		
	}

	void OnDisable()
	{
		//EventManager.StopListening("Trigger", listener);
	}

	void TestFunction()
	{
		this.gameObject.SetActive (true);
	}



}
