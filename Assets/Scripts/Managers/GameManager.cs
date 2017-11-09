using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonBase<GameManager>
{
    int score;
    protected override void Init(){}

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        GameObjectManager.Instance.InitPlayer();
    }
    
    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChange(score);
    }
    void OnScoreChange(int score)
    {
        UIManager.Instance.GetCanvas<HUDCanvas>().OnScoreChange(score);
    }
}