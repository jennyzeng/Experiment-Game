using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneControlCanvas : MonoBehaviour {

	public void StartGame(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void About()
	{
		SceneManager.LoadScene("about");
	}
}
