
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float yOffset;
    public float triggerRotationAngle;
    public float targetRotationAngle;
    public float smoothRotation;
    public float smoothMovement;
    
    private bool rotate;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + (target.transform.up * yOffset), Time.deltaTime * smoothMovement);
        
        if (!rotate && Quaternion.Angle(transform.rotation, target.transform.rotation) > triggerRotationAngle)
        {
            rotate = true;
        }
        
        if (rotate)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, target.transform.rotation.eulerAngles.z, Time.deltaTime * smoothRotation));
            if (Quaternion.Angle(transform.rotation, target.transform.rotation) < targetRotationAngle)
            {
                rotate = false;
            }
        }
    }

}