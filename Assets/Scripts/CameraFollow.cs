
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothedpositon = Vector3.Lerp(transform.position,desiredposition,smoothSpeed * Time.deltaTime);
        transform.position = smoothedpositon;
        transform.LookAt(target);
    }
   
}
