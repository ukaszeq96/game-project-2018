
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothRotation;
    public float smoothMovement;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * smoothMovement);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z,target.transform.rotation.eulerAngles.z,Time.deltaTime * smoothRotation));
    }

}