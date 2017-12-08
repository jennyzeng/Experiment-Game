using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : BaseCanvas
{
    string axis = "StopGame";


	void Start()
	{
		InputManager.RegisterAction(axis, StopGame);
		gameObject.SetActive(false);
	}

    void StopGame()
    {
        if (Input.GetButtonDown(axis))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
				gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
				gameObject.SetActive(true);
            }
        }
    }

}
