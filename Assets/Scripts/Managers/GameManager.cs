using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    int score;
    int levelScore;
    protected override void Init(){}

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
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
        UIManager.Instance.GetCanvas<HUDCanvas>().CloseCanvas();
        UIManager.Instance.GetCanvas<GameOverCanvas>().OpenCanvas(score);
        InputManager.Instance.enabled = false;
    }

    public void RestartGame()
    {
        /*
        TODO: need further editing after levels are created
        https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html
         */
        // Destroy(GameObjectManager.Instance.player);
        GameObjectManager.Instance.OnRestartGame();
        // Destroy(gameObject);
        InputManager.Instance.enabled = true;
        score = levelScore;
        UIManager.Instance.GetCanvas<GameOverCanvas>().CloseCanvas();
        Debug.Log(GameObjectManager.Instance.player);
        UIManager.Instance.GetCanvas<HUDCanvas>().OpenCanvas(score);
        // SceneManager.LoadScene("avatarTest", LoadSceneMode.Single);
         SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    public void BackToMenu()
    {
        Destroy(GameObjectManager.Instance.player);
        Destroy(gameObject);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelScore = score;
    }
}