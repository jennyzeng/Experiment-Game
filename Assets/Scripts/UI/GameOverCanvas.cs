using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverCanvas : BaseCanvas {

	public Text finalScoreText;
	void Awake()
	{// by default not active
		gameObject.SetActive(false);
	}

	public void OpenCanvas(int score)
	{
		gameObject.SetActive(true);
		finalScoreText.text = "SCORE: "+score.ToString();
	}

	public void CloseCanvas()
	{
		gameObject.SetActive(false);
	}

	public void RequestGameRestart()
	{
		GameManager.Instance.RestartGame();
	}

	public void RequestBackToMenu()
	{
		GameManager.Instance.BackToMenu();
	}
}
