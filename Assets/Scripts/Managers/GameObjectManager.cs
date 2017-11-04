using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : BaseManager {
	[HideInInspector]
	public GameObject player;
	public GameObject playerPrefab;
	// public HealthCanvas healthCanvas;

	// void Start()
	// {
	// 	player = Instantiate(playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
	// 		 EnvironmentUtil.Instance.playerSpawnPoint.rotation);
	// 	// foreach(PlayerAbility ability in player.GetComponentsInChildren<PlayerAbility>())
	// 	// {
	// 		// TODO: resource data loading should be added here in the future
	// 		// ability.Initialize();
	// 	// }
		
	// 	UIManager uIManager = GameManager.Instance.GetManager<UIManager>();
	// 	uIManager.Initialize();
	// 	player.GetComponent<PlayerHealth>().Initialize();
	// 	// uIManager.GetCanvas<SkillCanvas>().Initialize(player);
	// 	// healthCanvas = uIManager.GetCanvas<HealthCanvas>();
	// }
	public override void Initialize()
	{
		player = Instantiate(playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
			 EnvironmentUtil.Instance.playerSpawnPoint.rotation);
		// foreach(PlayerAbility ability in player.GetComponentsInChildren<PlayerAbility>())
		// {
			// TODO: resource data loading should be added here in the future
			// ability.Initialize();
		// }
		
		// UIManager uIManager = GameManager.Instance.GetManager<UIManager>();
		// uIManager.Initialize();
		player.GetComponent<PlayerHealth>().Initialize();		
	}
	public void OnPlayerDie()
	{
		// GameOverCanvas gameOverCanvas = GameManager.Instance.GetManager<UIManager>().GetCanvas<GameOverCanvas>();
		// gameOverCanvas.OnGameOver(score);
		player = null;
	}

}
