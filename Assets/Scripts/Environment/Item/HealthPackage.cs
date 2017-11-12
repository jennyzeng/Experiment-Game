using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : MedPackage {
    protected override void OnBeingPickedUp(Collider2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth.IsFullHP()) return;
        GameObjectManager.Instance.player.GetComponent<PlayerHealth>().AddHP(amount);
        Destroy(gameObject);
    }

}
