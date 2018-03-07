using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    public static float timeLeft;
    public static float timeMax = 200;
    private Text timer;
    // Use this for initialization
    void Start()
    {
        timer = GetComponent<Text>();
        timeLeft = timeMax;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
            timeLeft = 0;
        timer.text = "Time left: " + System.Math.Round(timeLeft,2);
    }
}
