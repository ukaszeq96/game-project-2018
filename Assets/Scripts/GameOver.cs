using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public Slider oxygen;
    public GameObject spaceship;

    // Update is called once per frame
    void Update() {
        if (oxygen.value <= 0 || Countdown.timeLeft <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
        if(Spaceship.partsDelivered == Spaceship.totalParts)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
    }
}
