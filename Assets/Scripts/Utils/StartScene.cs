using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

	void Start () {
		UIManager.Instance.gameObject.SetActive(false);
		InputManager.Instance.gameObject.SetActive(false);
	}

	public void OnButtonClick()
	{
		UIManager.Instance.gameObject.SetActive(true);
		InputManager.Instance.gameObject.SetActive(true);
	}
}
