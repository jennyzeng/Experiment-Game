using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour {
	public string ID;
	public float maxSpeed;
    protected Rigidbody2D rigid;
    protected Animator animator;
	public string axis;

	protected float coolDownTime;

	// Use this for initialization
	protected virtual void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

	public virtual void OnDisable()
	{
		if (InputManager.HasInstance())
			InputManager.UnregisterAction(axis);
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		InputManager.RegisterAction(axis, Action);
	}

	
	public virtual void Initialize()
	{
		ConfigDataSkill configData = new ConfigDataSkill();
		if (ResourceManager.Instance.configData.skill.TryGetValue(ID, out configData))
		{
			DataConfig(configData);
		}
	}	

	protected virtual void DataConfig(ConfigDataSkill configData)
	{
		if (!axis.Equals(configData.axis))
		{
			InputManager.UnregisterAction(axis);
			axis = configData.axis;
			InputManager.RegisterAction(axis, Action);
		}
		maxSpeed = configData.maxSpeed;
		coolDownTime = configData.coolDownTime;

	}
	public abstract void Action();
}
