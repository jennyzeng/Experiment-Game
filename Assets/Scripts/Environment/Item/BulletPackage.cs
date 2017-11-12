using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackage : CollectableObject
{
    public string id;
		private Bullet bulletPrefab;
    protected override void OnBeingPickedUp(Collider2D player)
    {
				PlayerHit playerHit = player.GetComponent<PlayerHit>();
				if (playerHit.IsBulletAlreadyCollected(id)) return;
				ConfigData();
        playerHit.AddBulletType(id, bulletPrefab);
        player.GetComponent<PlayerAbilitySwitcher>().SwitchBulletAndShowChangeOnUI(id);
        Destroy(gameObject);
    }

		void ConfigData()
		{
			ConfigDataBullet configData;
        if (ResourceManager.Instance.configData.bullet.TryGetValue(id, out configData))
        {
						bulletPrefab = Resources.Load<Bullet>(configData.bulletPrefab);
						if (bulletPrefab==null)
						{
							Debug.LogError("bullet prefab path does not exist: "+ configData.bulletPrefab);
						}
        }
				else
				{
						Debug.LogError("Bullet id "+ id + " does not exist");
				}
		}
}
