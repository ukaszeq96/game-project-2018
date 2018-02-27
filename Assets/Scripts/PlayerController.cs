using System;
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
    private Animator animator;

    public int shipPartCount;
    private int addToShipPartCount;
    private bool isGrounded;
    
    private float maxFalloutAngle = 2.5f;

    private int frameCount = 0;
    
    void Start()
    {
        shipPartCount = 0;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jetpackSlider.maxValue = jetpackMax;
        jetpack = jetpackMax;
    }

    void Update()
    {
        frameCount += 1;
        verInput = Input.GetAxis("Jump");
        horInput = Input.GetAxis("Horizontal");
        gravityDirection = transform.position - planet.position;
        gravityDirection.Normalize();
        
        if (raycastHit.collider != null) // all objects except PlatformTop are in IgnoreRaycast, so only when ray hits a platform raycasthit.collider != null
        {
            if (isGrounded)
            {
                // when on the ground, set (fix) the player transform rotation to prevent player from falling over
                // rotation is fixed only when falling at an angle higher than maxFalloutAngle
                if (Vector2.Angle(raycastHit.normal, transform.up) > maxFalloutAngle)
                {
                    transform.up = raycastHit.normal;
                }
            }
            else
                transform.up = Vector2.Lerp(transform.up, raycastHit.normal, Time.deltaTime * 3); // when in the air, rotate the player smoothly

        }
        else // when raycasthit.collider == null player rotates with respect to the surface of the planet
        {
            if (isGrounded)
            {
                // when on the ground, set (fix) the player transform rotation to prevent player from falling over
                // rotation is fixed only when falling at an angle higher than maxFalloutAngle
                if (Vector2.Angle(gravityDirection, transform.up) > maxFalloutAngle)
                {
                    transform.up = gravityDirection;
                }
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
        raycastHit = Physics2D.Raycast(transform.position, -transform.up, 5); // cast a ray downwards from the player and return the collider hit by the vector as well as normal of the surface that was hit
//        if (frameCount % 15 == 0)
//        {
//            bool isNull = (raycastHit.collider == null);
//            print("Raycast collider null? " + isNull);
//            if (raycastHit.collider == null)
//            {
////                print("Raycast hit: " + raycastHit);
//            }
//        }
        if (isGrounded)
        {
            rb.velocity = horInput * hor * movementSpeed;
            if (jetpack < jetpackMax)
                jetpack++;
        }
        else
        {
//            animator.SetTrigger("jump");
            rb.velocity = horInput * hor * movementSpeedAir;
        }
        if (verInput > 0 && jetpack > 0)
        {    
                rb.AddForce(verInput * ver * jumpSpeed);
                jetpack--;
        }

        if (horInput < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x < 0 ? transform.localScale.x : -1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            if (isGrounded)
            {
                animator.SetTrigger("run");
            }

        }
        else if (horInput > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x > 0 ? transform.localScale.x : -1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            if (isGrounded)
            {
                animator.SetTrigger("run");
            }
        }
        else animator.SetTrigger("idle");
    }

    void LateUpdate()
    {
        shipPartCount += addToShipPartCount;
        addToShipPartCount = 0;
        spc.UpdateShipPartCount(shipPartCount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform")  || other.gameObject.CompareTag("Planet"))
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                platform = other.gameObject.GetComponent<Transform>();
                this.transform.parent = platform.parent.transform;
            }
            isGrounded = true;
        }
        
        if (other.gameObject.CompareTag("ShipPart"))
        {
            addToShipPartCount = 1;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Planet"))
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                this.transform.parent = null;

            }
            isGrounded = false;
        }
    }
}