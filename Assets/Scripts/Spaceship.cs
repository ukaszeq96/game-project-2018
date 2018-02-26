using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
    public static int partsDelivered = 0;
    public static int totalParts;
    public GameObject player;
    public ShipPartCountController spc;
    void Awake()
    {
        totalParts = GameObject.FindGameObjectsWithTag("ShipPart").Length;

    }
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            partsDelivered += player.GetComponent<PlayerController>().shipPartCount;
            player.GetComponent<PlayerController>().shipPartCount = 0;
            spc.UpdateDeliveredPartCount();
            
        }
    }
}
