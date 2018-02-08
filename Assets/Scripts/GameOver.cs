using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public Slider oxygen;
    public Image background;
    public Button restartButton;


    private Text GameOverText;
    private Countdown countdown;

	void Start () {
        GameOverText = GetComponent<Text>();
        countdown = GameObject.Find("Timer").GetComponent<Countdown>();
        GameOverText.enabled = false;
        background.enabled = false;
        restartButton.GetComponent<Image>().enabled = false;
        restartButton.GetComponentInChildren<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (oxygen.value <= 0 || countdown.timeLeft <= 0)
        {
            background.enabled = true;
            GameOverText.enabled = true;
            restartButton.GetComponent<Image>().enabled = true;
            restartButton.GetComponentInChildren<Text>().enabled = true;
            Time.timeScale = 0;
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oxygen.value = oxygen.maxValue;
        countdown.timeLeft = countdown.timeMax;
        Time.timeScale = 1;

    }
}
