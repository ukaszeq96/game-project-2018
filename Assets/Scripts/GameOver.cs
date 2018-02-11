using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public Slider oxygen;
    private Countdown countdown;

	void Start () {
        countdown = GameObject.Find("Timer").GetComponent<Countdown>();
    }

    // Update is called once per frame
    void Update() {
        if (oxygen.value <= 0 || countdown.timeLeft <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
    }
}
