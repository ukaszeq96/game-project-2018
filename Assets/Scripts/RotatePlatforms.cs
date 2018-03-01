using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatforms : MonoBehaviour
{
    public enum Direction
    {
        Left = 1,
        Right = -1
    }
    
    public  Transform planet;
    public float rotationSpeed;
    public Direction direction;

    void Update()
    {
        int directionSign = (int) direction;
        foreach (Transform child in transform)
        {
            child.RotateAround(planet.position, directionSign * Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
