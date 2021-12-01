using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandySplode : MonoBehaviour
{
    public GameObject sploady;
    public float totalSplodeTime = 8f;
    public float splodeDelay = 0.4f;

    float duration;
    float splodeTime;
    Vector2 screenHalfSize;

    private void Start()
    {
        duration = Time.time + totalSplodeTime;
        splodeTime = Time.time + splodeDelay;
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void Update()
    {
        if (Time.time > duration)
        {
            Destroy(gameObject);
        }

        if (Time.time > splodeTime)
        {
            Instantiate(sploady, new Vector3(Random.Range(-screenHalfSize.x, screenHalfSize.x), Random.Range(-screenHalfSize.y, screenHalfSize.y)), transform.rotation);
            splodeTime = Time.time + splodeDelay;
        }
    }
}
