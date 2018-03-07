using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour
{
    public Vector3 pointB;
    private Vector3 hiddenScale = new Vector3(1, 0.7f, 1);

    IEnumerator Start()
    {
        Vector3 pointA = transform.localPosition;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1,false));
            yield return new WaitForSeconds(Random.Range(2, 4));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA,1, true));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time, bool grow)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
            if (grow)
                thisTransform.localScale = Vector3.Lerp(hiddenScale, Vector3.one, i);
            else
                thisTransform.localScale = Vector3.Lerp(Vector3.one, hiddenScale, i);
            yield return null;
        }
    }
}