using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSploadyTrigger : MonoBehaviour
{
    public GameObject sploady;
    public GameObject randomSploader;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(sploady, transform.position, transform.rotation);
            Instantiate(randomSploader, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
