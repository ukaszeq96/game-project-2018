using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {
    public float normalSize;
    public float zoomedSize;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))

            Camera.main.orthographicSize = zoomedSize;
        else
            Camera.main.orthographicSize = normalSize;
	}
}
