using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour {
    //[SerializeField]
    //Transform planet;

    //[SerializeField]
    //float gravitationpull;

    [SerializeField]
    float movementMultiplier;

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * movementMultiplier, Input.GetAxis("Vertical") * movementMultiplier));
        //Vector2 diff = planet.transform.position - this.transform.position;
        //rb.AddForce((diff).normalized * gravitationpull);
        //float angle = Mathf.Atan2(diff.x, diff.y);
        //this.transform.rotation = Quaternion.AngleAxis(angle, transform.up);
	}
}
