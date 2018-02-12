using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {
    private static int shipPartCount;
    public GameObject levelTime;
	// Use this for initialization
	void Start () {
        shipPartCount = PlayerController.shipPartCount;
        if(shipPartCount == 3)
        {
            levelTime.SetActive(true);
        }
        else
        {
            levelTime.SetActive(false);
        }
    }
}
