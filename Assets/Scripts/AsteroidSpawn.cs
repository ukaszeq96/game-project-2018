using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {
    public GameObject asteroidobj; //exposed variable to pass the object
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0,800)<10) //every 10 in 1100 an asteroid is going to be generated
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-30f,30f),
                                        this.transform.position.y,
                                        this.transform.position.z);

            Instantiate(asteroidobj, pos, asteroidobj.transform.rotation);
        }
	}
}
