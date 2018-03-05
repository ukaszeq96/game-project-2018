using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAsteroid : MonoBehaviour {
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        ps.Play();
        sr.enabled = false;
        rb.simulated = false;
        Destroy(gameObject,2);
    }
}
