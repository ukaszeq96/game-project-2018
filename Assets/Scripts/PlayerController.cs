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
    private Transform platform;
    private Quaternion rotationToPlanet;

    private bool isGrounded;
    private bool isOnPlatform;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        gravityDirection = planet.position - transform.position;
        gravityDirection.Normalize();
        float rot_z = Mathf.Atan2(gravityDirection.y, gravityDirection.x) * Mathf.Rad2Deg;
        rotationToPlanet = Quaternion.Euler(0f, 0f, rot_z + 90);
        if (!isOnPlatform)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlanet, Time.deltaTime * 10);
            transform.rotation = rotationToPlanet; // if the player is not standing on a platform, rotate the player to planet

        }
        else
        {
           //transform.rotation = Quaternion.Lerp(transform.rotation, platform.transform.rotation, Time.deltaTime * 10);
           transform.rotation = platform.transform.rotation; // set the player's rotation to the rotation of the platform
        }



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
        if (other.gameObject.CompareTag("Platform") && !isGrounded)
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("PlatformTop") && !isOnPlatform)
        {
            platform = other.GetComponent<Transform>(); // get the transform of the platform the player is currently standing on
            isOnPlatform = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform") && isGrounded)
        {
            isGrounded = false;
        }
        if (other.gameObject.CompareTag("PlatformTop") && isOnPlatform)
        {
            isOnPlatform = false;
        }
    }
}