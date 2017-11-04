using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float outForce = 1f;
    [HideInInspector]
    public int damageAmount;
    Rigidbody2D rigid;
    Animator anim;
    public void initialize(float outForce, int damageAmount)
    {
        this.outForce = outForce;
        this.damageAmount = damageAmount;
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(outForce, 0), ForceMode2D.Impulse);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		Health health = other.collider.gameObject.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(damageAmount);
		}

        Destroy(gameObject);
    }
}
