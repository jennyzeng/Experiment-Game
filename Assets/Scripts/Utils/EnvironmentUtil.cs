using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentUtil : SingletonBase<EnvironmentUtil> {


	public Transform playerSpawnPoint;
	public GameObject enemyContainer;
	public Door door;
	[HideInInspector]
	public int enemyCounter;

	protected override void Init()
	{
		
	}
	void Awake()
	{
		enemyCounter = enemyContainer.transform.childCount;

	}

   public bool IsAllEnemyDestroyed()
   {
	   return enemyCounter == 0;
   }
}
