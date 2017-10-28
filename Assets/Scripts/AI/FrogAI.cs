using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour {
	public float maxSpeed = 3f;
	public float jumpPower = 5f;
	public float monitor_range = 10f;
	public bool facingRight = true;
	Rigidbody2D rigid;
	Animator anim;
	bool grounded = true;
	GameObject player = null;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D>();
//		player = GameManager.Instance.GetManager<GameObjectManager> ().player;
	}
	
	void FixedUpdate () {
		if(player == null) player = GameManager.Instance.GetManager<GameObjectManager> ().player;
		if (player == null)
			return;

		if (rigid.velocity.y == 0 && !grounded)
			grounded = true;
			// anim.SetBool ("inair", false);

		if (grounded) {
			grounded = false;
			// anim.SetBool ("inair", true);
			anim.SetTrigger ("Jump1");
			float move = 1;
			if (Mathf.Abs (player.transform.position.x - transform.position.x) > monitor_range) {
				move = (Random.Range (0, 2) == 0) ? -1 : 1;
			} else {
				move = (player.transform.position.x - transform.position.x > 0) ? 1 : -1;
			}

			if ((move > 0 && !facingRight) || (move < 0 && facingRight)) Flip();
			rigid.velocity = new Vector2(move * maxSpeed, jumpPower);
		}
			
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
