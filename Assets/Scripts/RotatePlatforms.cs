using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatforms : MonoBehaviour
{
    [SerializeField]
    Transform planet;

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
    void FixedUpdate()
    {
        //int i = 0;
        foreach (Transform child in transform)
        {
            child.RotateAround(planet.position, Vector3.forward, 10 * Time.deltaTime);
            //child.RotateAround(planet.position, Vector3.forward, speeds[i] * Time.deltaTime);
            //i++;
        }
    }
}
