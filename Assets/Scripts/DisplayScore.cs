using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    private static int shipPartCount;
    public GameObject levelTime;
    public Text gameOverText;
	// Use this for initialization
	void Start () {
        //shipPartCount = PlayerController.shipPartCount;
        if(Spaceship.partsDelivered == Spaceship.totalParts)
        {
            levelTime.SetActive(true);
            gameOverText.text = "Victory!";
        }
        else
        {
            levelTime.SetActive(false);
        }
    }
}
