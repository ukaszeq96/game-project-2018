
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime);
    }

}
