using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : BaseManager {
	[HideInInspector]
	public GameObject player;
	public GameObject playerPrefab;
	// public HealthCanvas healthCanvas;
	int score; // player score
	

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Start()
	{
		player = Instantiate(playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
			 EnvironmentUtil.Instance.playerSpawnPoint.rotation);
		// UIManager uIManager = GameManager.Instance.GetManager<UIManager>();
		// uIManager.Initialize();
		// player.GetComponent<PlayerHealth>().Initialize();
		// uIManager.GetCanvas<SkillCanvas>().Initialize(player);
		// healthCanvas = uIManager.GetCanvas<HealthCanvas>();
		OnScoreChange();
	}

	void OnScoreChange()
	{
		// healthCanvas.ChangeScoreText(score);
		// if (EnvironmentUtil.Instance.IsAllEnemyDestroyed())
		// {
		// 	// win
		// 	GameOverCanvas gameOverCanvas = GameManager.Instance.GetManager<UIManager>().GetCanvas<GameOverCanvas>();
		// 	gameOverCanvas.OnWin(score);
		// }
	}

	public void OnPlayerDie()
	{
		// GameOverCanvas gameOverCanvas = GameManager.Instance.GetManager<UIManager>().GetCanvas<GameOverCanvas>();
		// gameOverCanvas.OnGameOver(score);
		player = null;
	}
	
	public void AddScore(int score)
	{
		this.score += score;
		OnScoreChange();
	}
}
