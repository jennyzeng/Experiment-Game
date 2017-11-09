using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : MedPackage {
    protected override void ActionWhenCollected()
    {
        PlayerHealth playerHealth = GameObjectManager.Instance.player.GetComponent<PlayerHealth>();
        if (playerHealth.IsFullHP()) return;
        GameObjectManager.Instance.player.GetComponent<PlayerHealth>().AddHP(amount);
        Destroy(gameObject);
    }

}
