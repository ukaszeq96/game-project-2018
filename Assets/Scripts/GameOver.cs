using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public Slider oxygen;
    private int shipPartCount;


    // Update is called once per frame
    void Update() {
        if (oxygen.value <= 0 || Countdown.timeLeft <= 0 || PlayerController.shipPartCount == 3)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
    }
}
