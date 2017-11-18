using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : InterativeItem
{
	public int damageAmount = 2;
    protected override void InteractAction(Collision2D player)
    {
		player.gameObject.GetComponentInChildren<PlayerHealth>().TakeDamage(2);
    }
}
