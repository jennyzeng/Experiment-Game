using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    static ConfigDataBullet configData;
    float outForce = 1f;
    float duration;
    [HideInInspector]
    int damageAmount;
    Rigidbody2D rigid;
    Animator anim;
    
    
    public static void ConfigBullet(string id)
    {   
         if (!ResourceManager.Instance.configData.bullet.TryGetValue(id, out configData))
            Debug.LogError("bullet config id "+ id + " does not exist");
    }

    public void initialize(bool facingRight)
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        outForce = configData.outForce;
        damageAmount = configData.damageAmount;
        duration = configData.duration;
        if (!facingRight)
        {
            MathTools.Flip(transform);
            rigid.AddForce(new Vector2(-outForce, 0), ForceMode2D.Impulse);
        }
        else
            rigid.AddForce(new Vector2(outForce, 0), ForceMode2D.Impulse);

        TimerManager.Instance.AddTimer(duration, gameObject, SelfDestroy);
        
    }
    
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		Health health = other.collider.gameObject.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(damageAmount);
		}
        SelfDestroy();
        
    }
}
