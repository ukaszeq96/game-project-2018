using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour
{
    public Slider oxygenSlider;
    
    private Rigidbody2D rb;
    public float moveOxygenMultiplier;
    public float jumpOxygenMultiplier;
    public float refillOxygenMultiplier;
    public float wormDamage;
    public float asteroidDamage;
    public AudioSource refill;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            oxygenSlider.value -= asteroidDamage;
            //Destroy(collision.gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Worm")
            oxygenSlider.value -= wormDamage;
        if (collider.gameObject.name == "Spaceship")
        {
            refill.Play();
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Worm")
        {
            oxygenSlider.value -= (wormDamage / 3) * Time.deltaTime;
        }
        else if (collider.gameObject.name == "Spaceship")
        {
            oxygenSlider.value += refillOxygenMultiplier * Time.deltaTime;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Spaceship")
        {
            refill.Stop();
        }
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Jump") == 0)
                oxygenSlider.value -= Time.deltaTime * moveOxygenMultiplier;
            else
                oxygenSlider.value -= Time.deltaTime * jumpOxygenMultiplier;
        }
        else
            oxygenSlider.value -= Time.deltaTime;
        if (Input.GetAxis("Jump") != 0)
            oxygenSlider.value -= Time.deltaTime * jumpOxygenMultiplier;
    }

    
}
