using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGunTrigger : MonoBehaviour
{
    public GameObject gun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(gun, new Vector3(0, 50, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
