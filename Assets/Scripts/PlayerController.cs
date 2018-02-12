using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform planet;
    public ShipPartCountController spc;
    public float movementSpeed;
    public float movementSpeedAir;
    public float jumpSpeed;
    public int jetpackMax;
    public Slider jetpackSlider;


    private Rigidbody2D rb;
    private Vector2 gravityDirection, ver, hor;
    private Transform platform;
    private RaycastHit2D raycastHit;
    private float verInput, horInput;
    private int jetpack;

    public static int shipPartCount;
    private int addToShipPartCount;
    private bool isGrounded;
    private bool isOnPlatform;
    
    void Start()
    {
        shipPartCount = 0;
        rb = GetComponent<Rigidbody2D>();
        jetpackSlider.maxValue = jetpackMax;
        jetpack = jetpackMax;
    }

    void Update()
    {
        
        verInput = Input.GetAxis("Jump");
        horInput = Input.GetAxis("Horizontal");
        gravityDirection = transform.position - planet.position;
        gravityDirection.Normalize();
        if (raycastHit.collider != null) // all objects except PlatformTop are in IgnoreRaycast, so only when ray hits a platform raycasthit.collider != null
        {
            if (isGrounded)
            {
                transform.up = raycastHit.normal; //when on the ground, set the rotation instantly to prevent player from falling over
            }
            else
                transform.up = Vector2.Lerp(transform.up, raycastHit.normal, Time.deltaTime * 3); // when in the air, rotate the player smoothly

        }
        else // when raycasthit.collider == null player rotates with respect to the surface of the planet
        {
            if (isGrounded)
            {
                transform.up = gravityDirection; // when on the ground, set the rotation instantly to prevent player from falling over

            }
            else
                transform.up = Vector2.Lerp(transform.up, gravityDirection, Time.deltaTime * 3); // when in the air, rotate the player smoothly
        }
        ver = transform.up;
        hor = Quaternion.Euler(0f, 0f, 90) * -ver;
        jetpackSlider.value = jetpack;
    }

    void FixedUpdate()
    {
        raycastHit =
            Physics2D.Raycast(transform.position, -transform.up,
                5); // cast a ray downwards from the player and return the collider hit by the vector as well as normal of the surface that was hit
        if (isGrounded)
        {
            rb.velocity = horInput * hor * movementSpeed;
            if (jetpack < jetpackMax)
                jetpack++;
        }
        else
        {
            rb.velocity = horInput * hor * movementSpeedAir;
        }
        if (verInput > 0)
        {
            if (jetpack > 0)
            {
                rb.AddForce(verInput * ver * jumpSpeed);
                jetpack--;
            }
        }
        if (horInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else if (horInput > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }

    void LateUpdate()
    {
        shipPartCount += addToShipPartCount;
        addToShipPartCount = 0;
        spc.UpdateShipPartCount(shipPartCount);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && !isGrounded)
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && isGrounded)
        {
            isGrounded = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlatformTop") && !isOnPlatform)
        {
            platform = other.gameObject.GetComponent<Transform>(); // get the transform of the platform the player is currently standing on
            this.transform.parent = platform.parent.parent.transform;
            isOnPlatform = true;
        }
        else if (other.gameObject.CompareTag("ShipPart"))
        {
            addToShipPartCount = 1;
            Destroy(other.gameObject);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlatformTop") && isOnPlatform)
        {
            this.transform.parent = null;
            isOnPlatform = false;
        }
    }
}