using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : SingletonBase<InputManager>
{
    Dictionary<String, Action> inputMap;

    // Use this for initialization
    // void Start () {
    // 	inputMap = new Dictionary<String, Action> ();
    // }
    protected override void Init()
    {
        Instance.inputMap = new Dictionary<String, Action>();
        transform.SetParent(GameManager.Instance.transform);
        // register in game manager		
    }
    public static void RegisterAction(String axis, Action action)
    {
        if (Instance.inputMap.ContainsKey(axis))
        {
            Debug.LogError("axis " + axis + " already assigned.");
            return;
        }
        Instance.inputMap.Add(axis, action);
    }

    public static void UnregisterAction(string axis)
    {
        Instance.inputMap.Remove(axis);
    }
    void Update()
    {
        foreach (KeyValuePair<String, Action> pair in inputMap)
        {
            if (Input.GetAxis(pair.Key) != 0)
            {
                pair.Value();
            }
        }
    }
}
