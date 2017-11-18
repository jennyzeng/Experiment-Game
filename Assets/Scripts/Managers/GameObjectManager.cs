using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : SingletonBase<GameObjectManager>
{
    [HideInInspector]
    public GameObject player;
    public GameObject playerPrefab;
    public Transform playerTransform;
    public bool isHumanMode=true;

    protected override void Init()
    {
        transform.SetParent(GameManager.Instance.transform);
    }

    public void SetIsHuman(Transform activeTransform, bool isHuman)
    {
        isHumanMode = isHuman;
        playerTransform = activeTransform;
    }
    public static void OnPlayerDie()
    {
    	Instance.player = null;
    }
    public void InitPlayer()
    {     
        player = Instantiate(Instance.playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
             EnvironmentUtil.Instance.playerSpawnPoint.rotation);
        foreach(PlayerHealth health in player.GetComponentsInChildren<PlayerHealth>())
        {
            if (health.enabled)
                health.Initialize();

        }
        // player.GetComponentInChildren<PlayerHealth>().Initialize();
        foreach(PlayerAbility playerAbility in player.GetComponents<PlayerAbility>())
        {
            playerAbility.Initialize();
        }
        // EnvironmentUtil.Instance.AferInit();
    }

    void SetPlayerStartLocationOnScene()
    {   
        player.transform.position = EnvironmentUtil.Instance.playerSpawnPoint.position;
        player.transform.rotation = EnvironmentUtil.Instance.playerSpawnPoint.rotation;
    }

}
