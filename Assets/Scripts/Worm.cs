//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Worm : MonoBehaviour
//{

//    public float cycleTime;
//    // Use this for initialization
//    void Start()
//    {
//        InvokeRepeating("Attack", Random.value * 3, cycleTime);

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(transform.localPosition == Vector3.zero)
//        transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.up, Time.deltaTime * 3);
//        else transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.up, Time.deltaTime * 3);

//    }

//    void Attack()
//    {

//    }
//}
using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour
{
    public Vector3 pointB = Vector3.up;

    IEnumerator Start()
    {
        Vector3 pointA = transform.localPosition;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 1));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}