using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    // Use this for initialization
    public int pairingcode; // it's the same for a given pair of teleporters
    float disabletimer = 0;
    //public GameObject cam;
    //CameraFollow cameraScript;
    SpriteRenderer sr;
    // Update is called once per frame
    void Start()
    {
         //cameraScript = cam.GetComponent<CameraFollow>();
         sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (disabletimer > 0)
        {
            disabletimer -= Time.deltaTime;
//            cameraScript.smoothRotation = 30;
//            cameraScript.smoothMovement = 3;
            sr.color = Color.grey;
        }
        else
        {
//            cameraScript.smoothRotation = 20;
//            cameraScript.smoothMovement = 1;
            sr.color = Color.blue;
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

                    tp.disabletimer = disabletimer = 3;
                    Vector3 position = tp.gameObject.transform.position;
                    //position.y += 2;
                    other.gameObject.transform.position = position;
                    other.gameObject.transform.rotation = tp.gameObject.transform.rotation;
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
