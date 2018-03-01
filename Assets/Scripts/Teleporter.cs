using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public int pairingCode; // it's the same for a given pair of teleporters
    public float teleportOffset;
    public float disableTime;
    public float rotateSpeed;
    
    [NonSerialized]
    public float disableTimer;

    private SpriteRenderer spriteRenderer;
    private Teleporter[] teleporters;
    private Teleporter targetTeleport;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        teleporters = FindObjectsOfType<Teleporter>();
    }
    void Update()
    {
        transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.forward);
        
        if (disableTimer > 0)
        {
            disableTimer -= Time.deltaTime;
            spriteRenderer.color = Color.grey;
        }
        else
            spriteRenderer.color = Color.blue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && disableTimer <= 0)
        {
            foreach (Teleporter otherTeleport in teleporters)
            {
                if (otherTeleport.pairingCode == pairingCode && otherTeleport != this)
                {
                    otherTeleport.disableTimer = disableTimer = disableTime;
                    
                    other.gameObject.transform.position = otherTeleport.gameObject.transform.position + (otherTeleport.gameObject.transform.up * teleportOffset);
                    other.gameObject.transform.rotation = otherTeleport.gameObject.transform.rotation;
                }
            }
        }
    }
}
