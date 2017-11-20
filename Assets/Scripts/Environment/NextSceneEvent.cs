using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneEvent : MonoBehaviour {

	public string nextSceneName;
	// Use this for initialization

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			LoadNewScene();
		}
	}

	void LoadNewScene(){
		SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
	}
}
