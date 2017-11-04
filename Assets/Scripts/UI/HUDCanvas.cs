using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : BaseCanvas {
	public Slider slider;

	public void OnHPchange(float value)
	{
		slider.value = value;
	}
	
}
