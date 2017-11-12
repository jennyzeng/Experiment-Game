using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHit))]
public class PlayerAbilitySwitcher : PlayerAbility
{
	PlayerHit playerAttackAbility;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	protected override void Start()
	{
		base.Start();
		playerAttackAbility = GetComponent<PlayerHit>();
		SwitchBulletAndShowChangeOnUI();
	}
    public override void Action()
    {
		// switch method
		if (Input.GetButtonDown(axis))
		{
			SwitchBulletAndShowChangeOnUI();
		}
    }
	public void SwitchBulletAndShowChangeOnUI()
	{
		BulletScriptable bulletScriptable = playerAttackAbility.SwitchBullet();
		ShowChangeOnUI(bulletScriptable);
	}
	public void SwitchBulletAndShowChangeOnUI(string id)
	{
		BulletScriptable bulletScriptable = playerAttackAbility.SwitchBullet(id);
		ShowChangeOnUI(bulletScriptable);
	}
	void ShowChangeOnUI(BulletScriptable bulletScriptable)
	{
		UIManager.Instance.GetCanvas<HUDCanvas>().OnBulletChange(bulletScriptable.bulletImg);
	}
}
