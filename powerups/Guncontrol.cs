using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guncontrol : MonoBehaviour
{
    public GameObject bullet;
    public float lifeSpan = 10f;
    public float rateOfFire = 0.15f;
    Vector3 playerPos; 

    bool left;

    float nextShot;
    float destroyTime;

    public static Guncontrol instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    void Start()
    {
        destroyTime = Time.time + lifeSpan;
        nextShot = Time.time + rateOfFire;
        playerPos = PlayerControllerBlochFall.Instance.transform.position;

    }

   
    void Update()
    {
        playerPos = PlayerControllerBlochFall.Instance.transform.position;
        if (Time.time > nextShot)
        {
            
            if (left == false)
            {
                Instantiate(bullet, new Vector3(playerPos.x + 3, playerPos.y), transform.rotation);
                left = true;
            }
            else
            {
                Instantiate(bullet, new Vector3(playerPos.x - 3, playerPos.y), transform.rotation);
                left = false;
            }
            nextShot = Time.time + rateOfFire;
        }

        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
