using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour
{
    public Slider slider;

    private Rigidbody2D rb;
    [SerializeField]
    float moveOxygenMultiplier;
    [SerializeField]
    float jumpOxygenMultiplier;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            slider.value -= 10;
            //Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Jump") == 0)
                slider.value -= Time.deltaTime * moveOxygenMultiplier;
            else
                slider.value -= Time.deltaTime * jumpOxygenMultiplier;
        }
        else
            slider.value -= Time.deltaTime;
        if (Input.GetAxis("Jump") != 0)
            slider.value -= Time.deltaTime * jumpOxygenMultiplier;
    }

    
}
