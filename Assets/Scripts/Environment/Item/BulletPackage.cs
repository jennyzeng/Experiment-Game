using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackage : CollectableObject
{
	public string id;
	public BulletScriptable bulletScriptable;
    protected override void OnBeingPickedUp(Collider2D player)
    {
		player.GetComponent<PlayerHit>().AddBulletType(id, bulletScriptable);
		player.GetComponent<PlayerAbilitySwitcher>().SwitchBulletAndShowChangeOnUI(id);
		Destroy(gameObject);
    }
}
