using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour {
    protected Rigidbody2D rigid;
    protected Animator animator;
	// Use this for initialization
	protected virtual void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	public abstract void Initialize();	
}
