using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : BaseManager {

	Dictionary<String, Action> inputMap;
	// Use this for initialization
	void Start () {
		inputMap = new Dictionary<String, Action> ();
	}

	public void RegisterAction(String axis, Action action)
	{
		if (inputMap.ContainsKey(axis)) 
		{
			Debug.LogError("axis "+ axis + " already assigned.");
			return;
		}
		inputMap.Add(axis, action);
	}
	
	public void UnregisterAction(string axis)
	{
		inputMap.Remove(axis);
	}
	void Update()
	{
		foreach(KeyValuePair<String, Action> pair in inputMap)
		{
			if (Input.GetAxis(pair.Key) != 0)
			{
				pair.Value();
			}
		}
	}
}
