using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonBase<GameManager>
{
    // singleton

    protected override void Init()
    {
        // InitManagers();

    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        GameObjectManager.InitPlayer();
    }
        
}