using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControlC : MonoBehaviour
{
    public float hSpeed = 0.15f;
    public float vSpeed = 0.15f;
    public float changeVelocityTime;
    public float changeVVelocityTime;
    public float lerpTime;
    public float lerpVTime;
    public float prevHSpeed;
    public float newHSpeed;
    public float prevVSpeed;
    public float newVSpeed;
    float t;
    float tV;

    public static BackgroundControlC instance { get; set; }

    private void Awake()
    {
        {
            if (instance != null && instance != this)
            {

                Destroy(gameObject);

            }


            instance = this;
        }
    }
    void Start()
    {
        changeVelocityTime = Time.time + 5f;
        newHSpeed = 0.02f;
        lerpTime = Random.Range(500f, 1000f);

        changeVVelocityTime = Time.time + 5f;
        newVSpeed = -0.01f;
        lerpVTime = Random.Range(500f, 1000f);


    }

   
    void Update()
    {
        if (hSpeed != newHSpeed)
        {
            t += 1f / lerpTime;
           hSpeed =  Mathf.SmoothStep(prevHSpeed, newHSpeed, t);
        }

        if (hSpeed == newHSpeed)
        {
            lerpTime = Random.Range(500f, 1000f);
            prevHSpeed = hSpeed;
            newHSpeed = Random.Range(-0.03f, 0.03f);
            t = 0f;
        }

        if (vSpeed != newVSpeed)
        {
            tV += 1f / lerpVTime;
            vSpeed = Mathf.SmoothStep(prevVSpeed, newVSpeed, tV);
        }

        if (vSpeed == newVSpeed)
        {
            lerpVTime = Random.Range(500f, 1000f);
            prevVSpeed = vSpeed;
            newVSpeed = Random.Range(-0.03f, 0.03f);
            tV = 0f;
        }

    }
}
