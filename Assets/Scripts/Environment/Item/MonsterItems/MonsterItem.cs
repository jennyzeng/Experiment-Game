using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterItem<T> : CollectableObject where T:PlayerAbility{
    public string abilityID;
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("called");
        if (other.gameObject.CompareTag("Player")){
			OnBeingPickedUp(other.collider);
		}
    }
    protected override void OnBeingPickedUp(Collider2D player)
    {
        if (!enabled) return;
        T ability = OnAddComponent(player);
        if(!ability.ID.Equals(abilityID)) 
        {
            ability.ID = abilityID;
            ability.Initialize();
            Destroy(gameObject);
        }
    }

    protected virtual T OnAddComponent(Collider2D player){
        T ability = player.GetComponent<T>();
        if (ability == null)
        {
            ability = player.gameObject.AddComponent(typeof(T)) as T;
        }
        return ability;
    }
} 
