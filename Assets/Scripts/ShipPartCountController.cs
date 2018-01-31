using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPartCountController : MonoBehaviour
{
	private Text shipCountText;
	
	void Start()
	{
		shipCountText = GetComponent<Text>();
	}

	public void UpdateShipPartCount(int count)
	{
		shipCountText.text = "Ship parts: " + count;
	}

}
