using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// multijump ability item
public class FrogJumpItem : MonsterItem<PlayerMultiJump> {
	protected override PlayerMultiJump OnAddComponent(Collider2D player)
	{
		GameObject human = player.transform.parent.GetComponent<BodySwitcher>().human;
		PlayerMultiJump ability = human.GetComponent<PlayerMultiJump>();
		if (ability==null)
		{
			ability = human.AddComponent<PlayerMultiJump>();
		}
		return ability;
	}
}
