using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour
{
    public Slider oxygenSlider;

    private Rigidbody2D rb;
    [SerializeField]
    float moveOxygenMultiplier;
    [SerializeField]
    float jumpOxygenMultiplier;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            oxygenSlider.value -= 10;
            //Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Worm")
            oxygenSlider.value -= 15;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Worm")
            oxygenSlider.value -= 5 * Time.deltaTime;
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
