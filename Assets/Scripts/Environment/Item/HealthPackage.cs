using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : MedPackage {
    protected override void ActionWhenCollected()
    {
        GameObjectManager.Instance.player.GetComponent<PlayerHealth>().AddHP(amount);
        Destroy(gameObject);
    }

}
