using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour {
	public string eventName;
	void OnDestroy() {
		EventManager.TriggerEvent(eventName);
	}
}
