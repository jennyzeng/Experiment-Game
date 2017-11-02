using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(EnemyHealth))]

public abstract class BaseAI : MonoBehaviour
{
    public bool facingRight = true;
    public float monitorRange = 10f;

    public Transform[] idleRoute;
    [HideInInspector]
    public bool isIdling;
    protected Rigidbody2D rigid;
    protected Animator anim;
    protected GameObject player;
    protected int nextIdlePoint;
    protected int next;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        if (idleRoute.Length == 0)
        {
            Debug.LogError("please add idle route for the monster " + gameObject.name);
            Destroy(gameObject);
        }
        nextIdlePoint = 1;
        next = 1;
        isIdling = true;
        transform.position = idleRoute[0].position;

    }

    protected virtual void FixedUpdate()
    {
        if (player == null)
            player = GameManager.Instance.GetManager<GameObjectManager>().player;
        if (player == null)
            return;
        if (Vector2.Distance(player.transform.position, transform.position) > monitorRange)
        {
            Idle();
        }
        else
        {
            FoundPlayerBehavior();
        }
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
            GoToNextPoint(idleRoute[nextIdlePoint].position);
            if (ShouldUpdateNextPoint())
            {
                if (nextIdlePoint >= idleRoute.Length-1 || nextIdlePoint == 0)
                {
                    next = -next;
                }
                nextIdlePoint += next;
            }
        }
    }
    protected abstract bool ShouldUpdateNextPoint();
    protected virtual void TransFromFollowPlayerToIdle()
    {
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
    // protected abstract bool ShouldGotoNextIdlePoint();
    protected abstract void GoToNextPoint(Vector2 nextPoint);
    protected virtual void FoundPlayerBehavior()
    {
        isIdling = false;
        if (rigid.velocity.y == 0)
            GoToNextPoint(player.transform.position);
    }

    protected virtual void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
