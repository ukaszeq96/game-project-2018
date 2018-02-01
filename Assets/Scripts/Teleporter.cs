using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    // Use this for initialization
    public int pairingcode; // it's the same for a given pair of teleporters
    float disabletimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (disabletimer > 0)
        {
            disabletimer -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && disabletimer <= 0)
        {

            foreach (Teleporter tp in FindObjectsOfType<Teleporter>())
            {
                if (tp.pairingcode == pairingcode && tp != this)
                {

                    tp.disabletimer = 2;
                    Vector3 position = tp.gameObject.transform.position;
                    //position.y += 2;
                    other.gameObject.transform.position = position;
                }
            }
        }
    }
    /*
        public GameObject objtotp;
        public Transform tpLoc;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "player")
            {
                objtotp.transform.position = tpLoc.transform.position;
            }
        }*/

}
