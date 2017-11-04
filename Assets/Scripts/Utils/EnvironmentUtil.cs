using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentUtil : MonoBehaviour {

private static EnvironmentUtil instance;

	public Transform playerSpawnPoint;
	public GameObject enemyContainer;
	public Door door;
	[HideInInspector]
	public int enemyCounter;

	void Awake()
	{
		if (instance!= null){
			if (instance != this)
				Destroy(instance.gameObject);
			else
			return;
		}
		EnvironmentUtil environmentUtil = GetComponent<EnvironmentUtil>();
		instance = environmentUtil;
		enemyCounter = enemyContainer.transform.childCount;

	}
   public static EnvironmentUtil Instance
   {
      get 
      {
         if (instance == null)
         {
			 Debug.LogError("No environment exists for current scene");
			 return null;
         }
         return instance;
      }
   }

	public void AferInit()
	{
		if (door != null)
			door.Trigger();
	}
   public bool IsAllEnemyDestroyed()
   {
	   return enemyCounter == 0;
   }
}
