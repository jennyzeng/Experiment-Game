using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

	public int maxHP;
	protected int curHP;
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
	protected virtual void OnDie()
	{
		anim.SetTrigger("Die");
	}
	protected virtual void OnDamage()
	{
		anim.SetTrigger("Hurt");
	}
	protected abstract void OnHPchange(int HP);
}