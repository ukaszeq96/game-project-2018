using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Slider oxygen;
    public Image background;

    private Text GameOverText;
    private Countdown countdown;

	void Start () {
        GameOverText = GetComponent<Text>();
        countdown = GameObject.Find("Timer").GetComponent<Countdown>();
        GameOverText.enabled = false;
        background.enabled = false;
	}

    // Update is called once per frame
    void Update() {
        if (oxygen.value <= 0 ||countdown.timeLeft <=0)
        {
            background.enabled = true;
            GameOverText.enabled = true;
            Time.timeScale = 0; // stop the game
        }

	}
}
