using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAI : MonoBehaviour
{
    public bool facingRight = true;
    public float monitor_range = 10f;
    public Transform[] idleRoute;
    protected Rigidbody2D rigid;
    protected Animator anim;
    protected GameObject player;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    protected virtual void Update()
    {
        if (player == null)
            player = GameManager.Instance.GetManager<GameObjectManager>().player;
        if (player == null)
            return;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > monitor_range)
        {
            Idle();
        }
        else
        {
            FoundPlayerBehavior();
        }
    }
    protected abstract void Idle();
    protected abstract void FoundPlayerBehavior();

}
