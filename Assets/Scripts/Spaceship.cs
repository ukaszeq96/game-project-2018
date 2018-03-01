using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
    public static int partsDelivered;
    public static int totalParts;
    public GameObject player;
    public ShipPartCountController spc;

    void Awake()
    {
        partsDelivered = 0;
        totalParts = GameObject.FindGameObjectsWithTag("ShipPart").Length;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            partsDelivered += player.GetComponent<PlayerController>().shipPartCount;
            player.GetComponent<PlayerController>().shipPartCount = 0;
            spc.UpdateDeliveredPartCount();
        }
    }
}
