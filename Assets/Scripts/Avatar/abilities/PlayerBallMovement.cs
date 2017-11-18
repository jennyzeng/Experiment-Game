using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMovement : PlayerAbility {
	

    public override void Action()
    {
        float move = Input.GetAxis(axis);
		rigid.velocity = new Vector2(0, rigid.velocity.y);
		rigid.velocity = new Vector2(maxSpeed*move, rigid.velocity.y);
		// rigid.AddForce(new Vector2(maxSpeed*move, 0), ForceMode2D.Impulse);
		
    }
	void OnBecameVisible()
	{
		InputManager.RegisterAction(axis, Action);
	}

	protected override void OnEnable(){
		GameObjectManager.Instance.SetIsHuman(transform, false);
	}

}
