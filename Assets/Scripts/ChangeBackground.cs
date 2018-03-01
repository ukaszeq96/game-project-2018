using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Sprite[] sprites;
    public float[] intervals;

    private int index;
    private float lastUpdate;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    void Update()
    {
        float currentTime = Time.fixedUnscaledTime;
        float interval = intervals[index];
        if (currentTime >= lastUpdate + interval)
        {
            if (sprites.Length == index + 1)
                index = 0;
            else
                index += 1;

            GetComponent<SpriteRenderer>().sprite = sprites[index];
            lastUpdate = currentTime;
        }
    }
}