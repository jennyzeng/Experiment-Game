using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Ball movement ability
public class SonicRunItem : MonsterItem<PlayerBallMovement> {
    protected override PlayerBallMovement OnAddComponent(Collider2D player)
    {
        player.transform.parent.GetComponent<BodySwitcher>().canSwitchToBall= true;
        Destroy(gameObject);
        return null;
    }
}