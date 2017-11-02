using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    protected override void OnDie()
    {
        base.OnDie();
        GetComponent<BaseAI>().enabled = false;
    }
	protected override void DestroyAction()
	{
		Debug.Log("destroy it");
		Destroy(transform.parent.gameObject); // destroy the enemy and the route
	}


    protected override void OnHPchange(int HP)
    {
        // throw new System.NotImplementedException();
    }
}
