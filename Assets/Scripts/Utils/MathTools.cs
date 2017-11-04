using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathTools {

	public static int LayerToNumber(int layerMask)
	{
		if (layerMask == 0) return 0;
		int number = 0;
		while (layerMask >> 1 != 0)
		{
			layerMask >>= 1;
			number += 1;
		}
		return number;
	}
}
