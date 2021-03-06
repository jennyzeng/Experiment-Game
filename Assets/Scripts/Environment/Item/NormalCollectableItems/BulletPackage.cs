﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackage : CollectableObject
{
    public string id;

    protected override void OnBeingPickedUp(Collider2D player)
    {
        BodySwitcher bodySwitcher= player.transform.GetComponentInParent<BodySwitcher>();
        GameObject human =  bodySwitcher.human;
        PlayerHit playerHit = human.GetComponent<PlayerHit>();
        if (playerHit.IsBulletAlreadyCollected(id)) return;
        Bullet bulletPrefab = ConfigData();
        playerHit.AddBulletType(id, bulletPrefab);
        human.GetComponent<PlayerAbilitySwitcher>().SwitchBulletAndShowChangeOnUI(id);
        Destroy(gameObject);
    }

    Bullet ConfigData()
    {
        ConfigDataBullet configData;
        Bullet bulletPrefab = null;
        if (ResourceManager.Instance.configData.bullet.TryGetValue(id, out configData))
        {
            bulletPrefab = Resources.Load<Bullet>(configData.bulletPrefab);
            if (bulletPrefab == null)
            {
                Debug.LogError("bullet prefab path does not exist: " + configData.bulletPrefab);
            }
        }
        else
        {
            Debug.LogError("Bullet id " + id + " does not exist");
        }
        return bulletPrefab;
    }
}
