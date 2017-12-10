using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowUpEvent : MonoBehaviour {
	private UnityAction listener;
	public string eventName;
	void Awake ()
	{
		listener = new UnityAction (ShowUp);
		EventManager.StartListening(eventName, listener);
		gameObject.SetActive (false);
	}

	void ShowUp()
	{
		gameObject.SetActive(true);
	}
}
