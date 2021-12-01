using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDestroyerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision. tag == "Player")
        {
            PlayerControllerBlochFall.Instance.isDestroyer = true;
            Destroy(gameObject);
        }
    }
}
