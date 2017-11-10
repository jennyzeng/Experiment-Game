using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartLogoCanvas : MonoBehaviour {

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	public float startAlpha;
	public float addAlpha;
	public Image image;
	Color newColor;
	void Start()
	{
		newColor = new Color(image.color.r, image.color.g, image.color.b, startAlpha);
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		ChangeAlpha();
	}
	void ChangeAlpha()
	{
		if (newColor.a >= 1) {
			SceneManager.LoadScene("Menu");
			return;
		}
		newColor.a += addAlpha;
		image.color = newColor;//new Color(newColor.r, newColor.g, newColor.b, newColor.a);
	}
}
