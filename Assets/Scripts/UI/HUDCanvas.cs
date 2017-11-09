using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : BaseCanvas {
	public Slider hpSlider;
	public Text scoreText;

	public void OnHPchange(float value)
	{
		hpSlider.value = value;
	}
	
	public void OnScoreChange(int score)
	{
		scoreText.text = "SCORE: "+ score.ToString();
	}
}
