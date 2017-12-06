using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour {

	public float loadingTime=5f;
	public float startTime;
	public string nextSceneName;
	public Text count;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		UIManager.Instance.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time-startTime > loadingTime)
		{
			UIManager.Instance.gameObject.SetActive(true);
			SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
			Destroy(gameObject);
		}
		count.text = ((int)(((Time.time-startTime)/loadingTime)*100)).ToString() + "%";
	}
}
