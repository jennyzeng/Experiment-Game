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
    	Instance.player = null;
    }
    public void InitPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player) 
        {
            SetPlayerStartLocationOnScene();
            return;
        }
        player = Instantiate(Instance.playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
             EnvironmentUtil.Instance.playerSpawnPoint.rotation);
        player.GetComponent<PlayerHealth>().Initialize();
        foreach(PlayerAbility playerAbility in player.GetComponents<PlayerAbility>())
        {
            playerAbility.Initialize();
        }
        EnvironmentUtil.Instance.AferInit();
    }

    void SetPlayerStartLocationOnScene()
    {   
        player.transform.position = EnvironmentUtil.Instance.playerSpawnPoint.position;
        player.transform.rotation = EnvironmentUtil.Instance.playerSpawnPoint.rotation;
    }

}
