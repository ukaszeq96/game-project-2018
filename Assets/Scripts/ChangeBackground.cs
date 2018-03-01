using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Sprite[] sprites;
    public float[] intervals;

    private SpriteRenderer spriteRenderer;
    private int index;
    private float lastUpdate;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[index];
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

            spriteRenderer.sprite = sprites[index];
            lastUpdate = currentTime;
        }
    }
}