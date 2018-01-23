using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    Transform planet;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float jumpSpeed;
    private Vector2 direction;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction = planet.position - transform.position;
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        if (Input.GetKey(KeyCode.Space))
        {
            print(" go up ");
        }
    }
    void FixedUpdate()
    {
        Vector2 ver = Input.GetAxis("Jump") * direction * -1;
        Vector2 hor = Quaternion.Euler(0f, 0f, 90) * direction;
        hor *= Input.GetAxis("Horizontal");
        rb.AddForce(ver * jumpSpeed);
        rb.AddForce(hor * movementSpeed);
        //rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * movementMultiplier, Input.GetAxis("Vertical") * movementMultiplier));
    }

}
