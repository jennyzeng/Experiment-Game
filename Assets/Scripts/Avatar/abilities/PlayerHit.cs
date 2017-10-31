using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : PlayerAbility {

    // use Fire1 axis
    public float coolDownTime = 0.1f;
    public float attackRange = 1f;
    public int attackAmount;
    public LayerMask layerMask;
    float lastTriggerTime;
    PlayerMovement playerMovement;
    BoxCollider2D boxCollider2D;
    protected override void Start()
    {
        base.Start();
        boxCollider2D = GetComponent<BoxCollider2D>();
        lastTriggerTime = Time.time;
        attackRange *= Mathf.Abs(transform.localScale.x);
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    public override void Action()
    {
        if (Time.time - lastTriggerTime >= coolDownTime)
        {
            DetectHit();
            lastTriggerTime = Time.time;
            animator.SetTrigger("Hit");
        }
    }

    void DetectHit()
    {
        RaycastHit2D hit;
        if (playerMovement.facingRight)
        {
             hit = Physics2D.Raycast(boxCollider2D.offset, Vector2.right, attackRange, layerMask);
             Debug.DrawRay(transform.position, Vector2.right*attackRange, Color.red, 2);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, attackRange, layerMask);
            Debug.DrawRay(transform.position, Vector2.left*attackRange, Color.red, 2);
        }
        if (hit.collider!=null)
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null) 
            {
                enemyHealth.TakeDamage(attackAmount);
            }
            else
            {
                Debug.LogError("Please add EnemyHealth script for GameObject "+ hit.collider.name);
            }
        }

    }


    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
