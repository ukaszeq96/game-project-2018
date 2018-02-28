using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForInput : MonoBehaviour {
    GameObject anyKeyPrompt;
     void Start()
    {
        anyKeyPrompt = GameObject.Find("IntroPanel");
        anyKeyPrompt.SetActive(true);
        Time.timeScale = 0;
    }
    void Update()
    {
        if(Time.timeScale == 0 && Input.anyKeyDown)
        {
            Time.timeScale = 1;
            anyKeyPrompt.SetActive(false);
        }
    }
}
