using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a package that can be collected by the player
// used to increase one status of the player
public abstract class MedPackage : CollectableObject {
	 
	 // will config with resources config data in the future
	 string ID;
	 // use amount to indicate the amount of effect
	public int amount;

	protected virtual void Init()
	{

	}
}
