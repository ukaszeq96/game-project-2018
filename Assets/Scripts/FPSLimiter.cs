using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{

	public int FPSLimit;

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = FPSLimit;
	}
	
}
