using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    public float lifeSpan = 0.2f;
    float destroyTime;
    void Start()
    {
        destroyTime = Time.time + lifeSpan;
        transform.rotation =  Quaternion.Euler(Vector3.forward * (Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
