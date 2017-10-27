using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour {
    protected Rigidbody2D rigid;
    protected Animator animator;
	public string axis;
	// Use this for initialization
	protected virtual void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

	public virtual void OnDisable()
	{
		if (GameManager.HasInstance())
			GameManager.Instance.GetManager<InputManager>().UnregisterAction(axis);
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		GameManager.Instance.GetManager<InputManager>().RegisterAction(axis, Action);
	}

	
	public abstract void Initialize();	// TODO: resource data loading should be added here in the future
	public abstract void Action();
}
