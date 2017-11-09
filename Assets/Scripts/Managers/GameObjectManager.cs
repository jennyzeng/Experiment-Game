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
    public static void InitPlayer()
    {
        Instance.player = Instantiate(Instance.playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
             EnvironmentUtil.Instance.playerSpawnPoint.rotation);
        Instance.player.GetComponent<PlayerHealth>().Initialize();
        EnvironmentUtil.Instance.AferInit();
    }

}
