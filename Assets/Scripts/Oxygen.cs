using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour {
    public Slider slider;

    private Rigidbody2D rb;
    
    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Jump") == 0)
            slider.value -= Time.deltaTime;
        else
            slider.value -= Time.deltaTime * 3;
    }
}
