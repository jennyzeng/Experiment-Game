using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneControlCanvas : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene("LoadingScene");
	}

	public void About()
	{
		SceneManager.LoadScene("about");
	}
}
