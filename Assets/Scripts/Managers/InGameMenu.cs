using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : BaseCanvas
{
    string axis = "StopGame";


	void Start()
	{
		InputManager.RegisterAction(axis, StopGameAction);
		gameObject.SetActive(false);
	}

    public void StopGameAction()
    {
        if (Input.GetButtonDown(axis))
        {
            StopGame();
        }
    }
    public void StopGame()
    {
        if (Time.timeScale == 0)
        {
            ResumeGame();
        }
        else
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
