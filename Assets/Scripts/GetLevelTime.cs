using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLevelTime : MonoBehaviour {
    private Text displayedTime;
	// Use this for initialization
	void Start () {
        float levelTime = Countdown.timeMax - Countdown.timeLeft;
        displayedTime = GetComponent<Text>();
        displayedTime.text = displayedTime.text + " " + levelTime + " s";
	}
}
