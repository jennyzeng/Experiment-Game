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
    public GameObject playerCopy;

    protected override void Init()
    {
        transform.SetParent(GameManager.Instance.transform);
        SceneManager.sceneLoaded += OnSceneLoaded;
        
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
        player = Instantiate(playerPrefab, EnvironmentUtil.Instance.playerSpawnPoint.position,
             EnvironmentUtil.Instance.playerSpawnPoint.rotation);
        foreach(PlayerHealth health in player.GetComponentsInChildren<PlayerHealth>())
        {
            // if (health.enabled)
                health.Initialize();

        }
        // player.GetComponentInChildren<PlayerHealth>().Initialize();
        foreach(PlayerAbility playerAbility in player.GetComponents<PlayerAbility>())
        {
            playerAbility.Initialize();
        }
        // EnvironmentUtil.Instance.AferInit();
    }
    void UpdatePlayerCopy(GameObject curPlayer)
    {
        if (playerCopy != null) {
            Destroy(playerCopy);
        }
        player.SetActive(false);
        playerCopy = Instantiate(player, transform);
        playerCopy.SetActive(false);
        player.SetActive(true);
    }

    public void OnRestartGame()
    {
        DestroyImmediate(player);
        player = Instantiate(playerCopy);
        player.SetActive(true);
        player.GetComponentInChildren<PlayerHealth>().ResetToFullHP();
    }
    public void SetPlayerStartLocationOnScene()
    {   
        player.transform.position = EnvironmentUtil.Instance.playerSpawnPoint.position;
        player.transform.rotation = EnvironmentUtil.Instance.playerSpawnPoint.rotation;
        for(int child = 0; child < player.transform.childCount; child++)
        {
            player.transform.GetChild(child).transform.localPosition=playerPrefab.transform.GetChild(child).localPosition;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (player!=null)
        {
            SetPlayerStartLocationOnScene();
        }
        UpdatePlayerCopy(player);
    }
}
