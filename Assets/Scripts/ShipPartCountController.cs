using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPartCountController : MonoBehaviour
{
	private Text carriedPartsText;
    private Text deliveredPartsText;
	
	void Start()
	{
		carriedPartsText = GetComponent<Text>();
        deliveredPartsText = GetComponent<Text>();
        deliveredPartsText.text = "Delivered parts: " + Spaceship.partsDelivered + "/" + Spaceship.totalParts;
    }

    public void UpdateShipPartCount(int count)
	{
		carriedPartsText.text = "Carried parts: " + count;
	}
    public void UpdateDeliveredPartCount()
    {
        deliveredPartsText.text = "Delivered parts: " + Spaceship.partsDelivered + "/" + Spaceship.totalParts;
    }

}
