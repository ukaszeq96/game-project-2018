
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;

    //void FixedUpdate()
    //{
    //    Vector3 desiredposition = target.position + offset;
    //    Vector3 smoothedpositon = Vector3.Lerp(transform.position,desiredposition,smoothSpeed * Time.deltaTime);
    //    transform.position = smoothedpositon;
    //    transform.LookAt(target);
    //}
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 10);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * smooth);
        //transform.position = target.transform.position;
        //transform.rotation = target.transform.rotation;
    }
   
}
