using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObject : MonoBehaviour {
    public GameObject objToFollow;
    private GameObject[] parts;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
        PositionArrow(objToFollow);
    }
    void PositionArrow(GameObject objToFollow)
    {
        GetComponent<Renderer>().enabled = false;
        if (objToFollow == null)
            return;
        Vector3 v3Pos = Camera.main.WorldToViewportPoint(objToFollow.transform.position);

        if (v3Pos.z < Camera.main.nearClipPlane)
            return;  // Object is behind the camera

        if (v3Pos.x >= 0.0f && v3Pos.x <= 1.0f && v3Pos.y >= 0.0f && v3Pos.y <= 1.0f)
            return; // Object center is visible

        GetComponent<Renderer>().enabled = true;
        v3Pos.x -= 0.5f;  // Translate to use center of viewport
        v3Pos.y -= 0.5f;
        v3Pos.z = 0;

        float fAngle = Mathf.Atan2(v3Pos.x, v3Pos.y);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -fAngle * Mathf.Rad2Deg);

        v3Pos.x = 0.5f * Mathf.Sin(fAngle) + 0.5f;  // Place on ellipse touching 
        v3Pos.y = 0.5f * Mathf.Cos(fAngle) + 0.5f;  //   side of viewport
        v3Pos.z = Camera.main.nearClipPlane + 0.01f;  // Looking from neg to pos Z;
        transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
    }
}
