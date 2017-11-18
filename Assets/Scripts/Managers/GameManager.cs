using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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
        OnScoreChange(score);
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

    public void GameOver()
    {
        UIManager.Instance.GetCanvas<HUDCanvas>().gameObject.SetActive(false);
        UIManager.Instance.GetCanvas<GameOverCanvas>().OpenCanvas(score);
    }


    public void RestartGame()
    {
        /*
        TODO: need further editing after levels are created
        https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html
         */
        Destroy(GameObjectManager.Instance.player);
        Destroy(gameObject);

        SceneManager.LoadScene("avatarTest", LoadSceneMode.Single);

    }

    public void BackToMenu()
    {
        Destroy(GameObjectManager.Instance.player);
        Destroy(gameObject);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}