using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour
{
    public Vector3 pointB;

    IEnumerator Start()
    {
        Vector3 pointA = transform.localPosition;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1));
            yield return new WaitForSeconds(Random.Range(2, 4));
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