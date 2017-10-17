using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

	public int maxHP;
	public int curHP;
	protected Animator anim;
	protected virtual void Start () {
		curHP = maxHP;
		anim = GetComponent<Animator>();
	}
	
	public virtual void TakeDamage(int amount)
	{
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
	protected abstract void OnDie();
	protected abstract void OnDamage();
	protected abstract void OnHPchange(int HP);
}