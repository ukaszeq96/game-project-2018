using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform planet;
    public float movementSpeed;
    public float movementSpeedAir;
    public float jumpSpeed;

    private Rigidbody2D rb;
    private Vector2 gravityDirection;
    
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        gravityDirection = planet.position - transform.position;
        gravityDirection.Normalize();
        
        float rot_z = Mathf.Atan2(gravityDirection.y, gravityDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        
        Vector2 ver = gravityDirection * -1;
        Vector2 hor = Quaternion.Euler(0f, 0f, 90) * gravityDirection;

        float verInput = Input.GetAxis("Jump");
        float horInput = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            rb.velocity = horInput * hor * movementSpeed;
        }
        else
        {
            rb.velocity = horInput * hor * movementSpeedAir;
        }

        if (verInput > 0)
        {
            rb.AddForce(verInput * ver * jumpSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Planet") && !isGrounded)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Planet") && isGrounded)
        {
            isGrounded = false;
        }
    }
}