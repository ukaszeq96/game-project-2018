
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.fixedDeltaTime * 10);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.fixedDeltaTime * smooth);

    }
   
}
