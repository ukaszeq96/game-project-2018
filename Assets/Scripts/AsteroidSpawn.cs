using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {
    
    public GameObject asteroidobj; //exposed variable to pass the object
    public int asteroidMaxCount;
    public float radius;
	void Update () {
       if(GameObject.FindGameObjectsWithTag("Asteroid").Length < asteroidMaxCount && Random.Range(0,100)<5)
        {
            Vector3 pos = RandomCircle(transform.position, radius); // asteroids are spawned at a random angle on the perimeter of the circle with a given radius and center at (0,0,1)
            Vector3 vecToTarget = pos - transform.position;
            float ang = Mathf.Atan2(vecToTarget.y, vecToTarget.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(ang + 90, Vector3.forward);
            Instantiate(asteroidobj,pos,rotation);
        }
	}
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = transform.position.z;
        return pos;
    }
}
