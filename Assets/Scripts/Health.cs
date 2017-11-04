using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

	public int maxHP;
	public float timeDisappearAfterDie;
	protected int curHP;
	protected Animator anim;
	protected virtual void Start () {
		curHP = maxHP;
		anim = GetComponent<Animator>();
	}
	
	public virtual void TakeDamage(int amount)
	{
		if (!enabled) return;
		Debug.Log("take damage");
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
		Debug.Log("on die");
		// anim.SetTrigger("Die");
		GameManager.Instance.GetManager<TimerManager>().AddTimer(
			timeDisappearAfterDie, gameObject, DestroyAction);
	}

	protected virtual void DestroyAction()
	{
		Debug.Log("destroy it");
		Destroy(gameObject);
	}
	protected virtual void OnDamage()
	{
		Debug.Log("On damage");
		// anim.SetTrigger("Hurt");
	}
	protected abstract void OnHPchange(int HP);
}