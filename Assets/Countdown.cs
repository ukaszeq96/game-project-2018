using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    [SerializeField]
    float timeLeft = 90.5f;
    private Text timer;
    // Use this for initialization
    void Start()
    {
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "Time left: " + (int)timeLeft;
    }
}
