using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : SingletonBase<InputManager>
{
    Dictionary<String, Action> inputMap;

    protected override void Init()
    {
        Instance.inputMap = new Dictionary<String, Action>();
        transform.SetParent(GameManager.Instance.transform);
        // register in game manager		
    }

    public static void UnregisterAllActions()
    {
        Instance.inputMap.Clear();
    }
    public static void RegisterAction(String axis, Action action, bool forceRegister = false)
    {
        if (Instance.inputMap.ContainsKey(axis))
        {
            if (!forceRegister)
            {
                Debug.LogError("axis " + axis + " already assigned for action" + action.Target + " .");
                return;
            }
            else
            {
                Instance.inputMap.Remove(axis);
                Instance.inputMap.Add(axis, action);
                Debug.Log("force register action "+action.Target + " to axis "+ axis);
                return;
            }
        }
        Instance.inputMap.Add(axis, action);
    }


    public static void UnregisterAction(string axis)
    {
        Instance.inputMap.Remove(axis);
    }
    void Update()
    {
        List<String>.Enumerator enumerator = new List<String>(Instance.inputMap.Keys).GetEnumerator();

        while (enumerator.MoveNext())
        {
            if (Input.GetAxis(enumerator.Current) != 0)
            {
                Action curAction;
                if (Instance.inputMap.TryGetValue(enumerator.Current, out curAction))
                {
                    curAction();
                }
            }
        }
    }
}
