using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : InterativeItem {

	public float magnitude = 10f;
  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  Animator animator;
  void Start()
  {
      animator = GetComponent<Animator>();
  }
    protected override void InteractAction(Collision2D other)
    {
      Vector2 offset = (Vector2)transform.position -other.contacts[0].point;
      animator.SetTrigger("spring");

      Rigidbody2D rigid = other.gameObject.GetComponent<Rigidbody2D>();
      Vector2 force = new Vector2(rigid.velocity.x, magnitude);
      rigid.velocity = force;
    }

}
