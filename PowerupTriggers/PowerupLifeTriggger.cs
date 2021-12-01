using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupLifeTriggger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreControl.ChangeLives(1);
            Destroy(gameObject);
        }
    }
}
