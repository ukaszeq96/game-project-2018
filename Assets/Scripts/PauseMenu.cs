using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeSelf == false)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }

	}
    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
