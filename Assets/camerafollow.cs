
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.125f;

    public

    void lateupdate()
    {
        transform.position = target.position;

    }
   
}
