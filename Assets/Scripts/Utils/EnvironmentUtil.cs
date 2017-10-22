﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentUtil : MonoBehaviour {

private static EnvironmentUtil instance;

	public Transform playerSpawnPoint;
	public GameObject enemyContainer;

	[HideInInspector]
	public int childCounter;

	void Start()
	{
		if (instance!= null){
			if (instance != this)
				Destroy(instance.gameObject);
			else
			return;
		}
		EnvironmentUtil environmentUtil = GetComponent<EnvironmentUtil>();
		instance = environmentUtil;
		childCounter = enemyContainer.transform.childCount;

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

   public bool IsAllEnemyDestroyed()
   {
	   return childCounter == 0;
   }
}