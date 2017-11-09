using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : SingletonBase<GameObjectManager>
{
    [HideInInspector]
    public GameObject player;
    public GameObject playerPrefab;


    protected override void Init()
    {
        transform.SetParent(GameManager.Instance.transform);
    }
    public static void OnPlayerDie()
    {
        // GameOverCanvas gameOverCanvas = GameManager.Instance.GetManager<UIManager>().GetCanvas<GameOverCanvas>();
        // gameOverCanvas.OnGameOver(score);
    	Instance.player = null;
    }
    public void InitPlayer()
    {
        player = Instantiate(Instance.playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
             EnvironmentUtil.Instance.playerSpawnPoint.rotation);
        player.GetComponent<PlayerHealth>().Initialize();
        foreach(PlayerAbility playerAbility in player.GetComponents<PlayerAbility>())
        {
            playerAbility.Initialize();
        }
        EnvironmentUtil.Instance.AferInit();
    }

}
