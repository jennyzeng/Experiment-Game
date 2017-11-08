using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    // singleton
    private static GameManager instance;

    private GameManager() { }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (instance != null)
        {
            if (instance != this)
                Destroy(instance.gameObject);
            else
                return;
        }
        GameManager gameManager = GetComponent<GameManager>();
        instance = gameManager;
        InitManagers();
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (!instance)
                {
                    Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene");
                    return null;
                }
                // GameObject go = new GameObject("GameManager");
                // instance = go.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    public static bool HasInstance()
    {
        return instance != null;
    }
    public BaseManager[] preLoadManagerList;
    private List<BaseManager> managerList;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void InitManagers()
    {
        managerList = new List<BaseManager>();
        foreach (BaseManager manager in preLoadManagerList)
        {
            BaseManager managerInstance = Instantiate(manager, transform);
            managerInstance.Initialize();
            managerList.Add(managerInstance);
        }
    }
    void ClearManagers()
    {
        foreach (BaseManager manager in managerList)
        {
            Destroy(manager);
        }
        managerList = null;
    }

    public T GetManager<T>() where T : BaseManager
    {
        if (managerList == null)
        {
            Debug.LogError("Managers have not yet initiated.");
            return null;
        }
        BaseManager manager = managerList.Find(item => item is T);
        if (manager == null)
        {
            Debug.LogError("Failed to get " + manager.name + " because it is not registered");
            return null;
        }
        return manager as T;
    }

    public bool IsManagersinitiated()
    {
        return managerList != null;
    }
}