using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatforms : MonoBehaviour
{
    [SerializeField]
    Transform planet;
    [SerializeField]
    int rotationSpeed;

    //private List<int> speeds = new List<int>();
    // Use this for initialization
    void Start()
    {
        //foreach (Transform child in transform)
        //{
        //    speeds.Add(Random.Range(0, 20));
        //}
    }
    // Update is called once per frame
    void Update()
    {
        //int i = 0;
        foreach (Transform child in transform)
        {
            child.RotateAround(planet.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            //child.RotateAround(planet.position, Vector3.forward, speeds[i] * Time.deltaTime);
            //i++;
            //   transform.position= new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, 0 );
           // transform.Translate(transform.forward * Mathf.Cos(Time.time) * Time.deltaTime);
        }
    }
}
