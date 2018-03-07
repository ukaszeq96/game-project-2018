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
    public float movementSpeedJetpack;
    public float movementSpeedAir;
    public float jumpSpeed;
    public int jetpackMax;
    //public int jetpackRegenerateSlowdownFactor;
    public float maxFalloutAngle;
    public Slider jetpackSlider;
    public AudioSource jetpackSound;

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
        verInput = Input.GetAxis("Jump");
        horInput = Input.GetAxis("Horizontal");

        if (raycastHit.collider != null)
            gravityDirection = raycastHit.normal;
        else
            gravityDirection = transform.position - planet.position;
        gravityDirection.Normalize();
        
        // when on the ground, set (fix) the player transform rotation to prevent player from falling over
        // rotation is fixed only when falling at an angle higher than maxFalloutAngle
        if (Vector2.Angle(gravityDirection, transform.up) > maxFalloutAngle)
            transform.up = gravityDirection;
        else
            transform.up = Vector2.Lerp(transform.up, gravityDirection, Time.deltaTime * 3); // when in the air, rotate the player smoothly
        
        ver = transform.up;
        hor = Quaternion.Euler(0f, 0f, 90) * -ver;
        jetpackSlider.value = jetpack;
    }

    void FixedUpdate()
    {
        raycastHit = Physics2D.Raycast(transform.position, -transform.up, 5); // cast a ray downwards from the player and return the collider hit by the vector as well as normal of the surface that was hit
        if (isGrounded)
        {
            rb.velocity = horInput * hor * movementSpeed;
            //bool regenerateJetpack = jetpackRegenerateSlowdownFactor <= 0 || Time.frameCount % jetpackRegenerateSlowdownFactor == 0;
            if (jetpack < jetpackMax)
                jetpack += 2;
        }
        else if (verInput > 0 && jetpack > 0)
            rb.velocity = horInput * hor * movementSpeedJetpack;
        else
            rb.velocity = horInput * hor * movementSpeedAir;
        
        if (verInput > 0 && jetpack > 0)
        {
            if (!isGrounded || jetpack>(jetpackMax * 0.1f))
            {
                if (!jetpackSound.isPlaying)
                    jetpackSound.Play();
            
                rb.AddForce(verInput * ver * jumpSpeed);
                jetpack -= 1;
            }

        }
        else
        {
            if (jetpackSound.isPlaying)
                jetpackSound.Stop();
        }
        
        bool isInTransition = animator.IsInTransition(0);
        bool isRunning = animator.GetCurrentAnimatorStateInfo(0).IsName("run");
        bool isJetpacking = animator.GetCurrentAnimatorStateInfo(0).IsName("jetpack");
        bool isIdling = animator.GetCurrentAnimatorStateInfo(0).IsName("idle");

        if (verInput > 0 && jetpack > 0)
        {
            if (!isJetpacking && !isInTransition)
                animator.SetTrigger("jetpack");
        }
        else if (verInput > 0 && !isGrounded)
        {
            if (!isIdling && !isInTransition)
                animator.SetTrigger("idle");
        }
        else if (horInput != 0 && isGrounded)
        {
            if (!isRunning && !isInTransition)
                animator.SetTrigger("run");
        }
        else
        {
            if (!isIdling && !isInTransition)
                animator.SetTrigger("idle");
        }

        if (horInput < 0)
            transform.localScale = new Vector3(transform.localScale.x < 0 ? transform.localScale.x : -1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        else if (horInput > 0)
            transform.localScale = new Vector3(transform.localScale.x > 0 ? transform.localScale.x : -1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
                transform.parent = platform.parent.transform;
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
                transform.parent = null;
            isGrounded = false;
        }
    }
}