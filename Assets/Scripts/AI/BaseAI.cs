using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(EnemyHealth))]

public abstract class BaseAI : MonoBehaviour
{
    public bool facingRight = true;
    public float monitorRange = 10f;
    public int damageAmount;
    public Transform[] idleRoute;
    [HideInInspector]
    public bool isIdling;
    protected Rigidbody2D rigid;
    protected Animator anim;
    protected GameObject player;
    public Transform playerTransform;
    protected int nextIdleIdx;
    protected Vector2 nextTargetPoint;
    protected int next;
    protected EnemyHealth enemyHealth;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
        if (idleRoute.Length == 0)
        {
            Debug.LogError("please add idle route for the monster " + gameObject.name);
            Destroy(gameObject);
        }
        nextIdleIdx = 1;
        nextTargetPoint = idleRoute[nextIdleIdx].position;
        next = 1;
        isIdling = true;
        transform.position = idleRoute[0].position;
    }

    protected virtual void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObjectManager.Instance.player;
            if (player == null)
                return;
        }
        if (!DetectPlayer())
        {
            Idle();
        }
        else
        {
            FoundPlayerBehavior();
        }
    }

    protected virtual bool DetectPlayer()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > monitorRange)
            return false;
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        // if there are any blocks between ai and player, it cannot find the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, LayerMask.GetMask("Platforms"));
        // Debug.DrawLine(transform.position, transform.position + direction * distance, Color.red, 2f);
        return hit.collider == null;
        
    }
    protected virtual void Idle()
    {
        if (!isIdling)
        {// start idling
            TransFromFollowPlayerToIdle();
            isIdling = true;
            return;
        }
        if (NeedCommand())
        {
            GoToNextPoint(nextTargetPoint);
            if (ShouldUpdateNextPoint())
            {
                if (nextIdleIdx >= idleRoute.Length-1 || nextIdleIdx == 0)
                {
                    next = -next;
                }
                nextIdleIdx += next;
                nextTargetPoint = idleRoute[nextIdleIdx].position;
            }
        }
    }
    protected abstract bool ShouldUpdateNextPoint();
    protected virtual void TransFromFollowPlayerToIdle()
    {
        // find the closet idle point
        Vector2 minpoint = transform.position;
        float minDistance = float.MaxValue;
        foreach (Transform point in idleRoute)
        {
            float thisDistance = Vector2.Distance(transform.position, point.position);
            if (thisDistance < minDistance)
            {
                minpoint = point.position;
                minDistance = thisDistance;
            }
        }
        GoToNextPoint(minpoint);
    }

    protected abstract bool NeedCommand();

    protected abstract void GoToNextPoint(Vector2 nextPoint);
    protected virtual void FoundPlayerBehavior()
    {
        isIdling = false;
        if (nextTargetPoint.Equals(idleRoute[nextIdleIdx].position))
            nextTargetPoint = player.transform.position;
        if (rigid.velocity.y == 0)
            GoToNextPoint(nextTargetPoint);
    }

    protected virtual void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        enemyHealth.FlipHealthCanvas();
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (enabled && other.collider.CompareTag("Player"))
        {
            foreach(PlayerHealth health in other.collider.gameObject.GetComponents<PlayerHealth>())
            if (health.enabled)
                health.TakeDamage(damageAmount);
        }
    }
}
