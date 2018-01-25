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
    private Vector2 gravityDirection, ver, hor;
    private Transform platform;
    //private Quaternion rotationToPlanet;
    private RaycastHit2D raycastHit;
    private float verInput, horInput;

    private bool isGrounded;
    private bool isOnPlatform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verInput = Input.GetAxis("Jump");
        horInput = Input.GetAxis("Horizontal");
        gravityDirection = transform.position - planet.position;
        gravityDirection.Normalize();

        if (raycastHit.collider != null)
        {
                //transform.up = raycastHit.normal; // rotation is not smooth, but the horizontal movement works normally
                transform.up = Vector2.Lerp(transform.up, raycastHit.normal, Time.deltaTime * 10); // rotation is smooth, but the horizontal movement breaks
            ver = transform.up;

        }
        else
        {
            //    transform.up = gravityDirection; // rotation is not smooth, but the horizontal movement works normally
            transform.up = Vector2.Lerp(transform.up, gravityDirection, Time.deltaTime * 5); // rotation is smooth, but the horizontal movement breaks
            ver = gravityDirection;
        }
        ver = transform.up;
        hor = Quaternion.Euler(0f, 0f, 90) * -ver;
    }
    void FixedUpdate()
    {
        raycastHit = Physics2D.Raycast(transform.position, -transform.up, 1);

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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && !isGrounded)
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("PlatformTop") && !isOnPlatform)
        {
            platform = other.gameObject.GetComponent<Transform>(); // get the transform of the platform the player is currently standing on
            this.transform.parent = platform.parent.parent.transform;
            isOnPlatform = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && isGrounded)
        {
            isGrounded = false;
        }
        if (other.gameObject.CompareTag("PlatformTop") && isOnPlatform)
        {
            this.transform.parent = null;
            isOnPlatform = false;
        }
    }
}