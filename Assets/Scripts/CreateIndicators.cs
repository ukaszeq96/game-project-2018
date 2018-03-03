using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIndicators : MonoBehaviour {
    GameObject[] parts;
    public GameObject indicator;
	// Update is called once per frame
	void Start () {
        parts = GameObject.FindGameObjectsWithTag("ShipPart");
        foreach(GameObject part in parts)
        {
            GameObject partIndicator = Instantiate(indicator);
            partIndicator.GetComponent<PointToObject>().objToFollow = part;
            partIndicator.transform.parent = Camera.main.transform;
        }
	}
}
