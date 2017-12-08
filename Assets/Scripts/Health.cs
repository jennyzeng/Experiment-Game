using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

	public int maxHP;
	public float timeDisappearAfterDie;
	public int curHP;
	protected Animator anim;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	protected virtual void Awake()
	{
		curHP = maxHP;
		anim = GetComponent<Animator>();
	}
	
	public virtual void TakeDamage(int amount)
	{
		if (!enabled) return;
		curHP -= amount;
		if (curHP <= 0 ){
			curHP = 0;
			OnDie();
		}
		else{
			OnDamage();
		}
		OnHPchange(curHP);
	}
	protected virtual void OnDie()
	{
		// anim.SetTrigger("Die");
		TimerManager.Instance.AddTimer(
			timeDisappearAfterDie, gameObject, DestroyAction);
	}

	protected virtual void DestroyAction()
	{
		Destroy(gameObject);
	}
	protected virtual void OnDamage()
	{
		// anim.SetTrigger("Hurt");
	}
	protected abstract void OnHPchange(int HP);
}