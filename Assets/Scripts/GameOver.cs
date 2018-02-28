using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public Slider oxygen;
    public GameObject spaceship;
    public AudioSource deathSound;

    private float delay = 0.5f; // time in seconds to delay loading GameOver scene
    // Update is called once per frame
    void Update() {
        if (oxygen.value <= 0 || Countdown.timeLeft <= 0)
        {
            if (!deathSound.isPlaying)
                deathSound.Play();
            delay -= Time.deltaTime;

            if(delay<=0)
                SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
        if(Spaceship.partsDelivered == Spaceship.totalParts)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
    }
}
