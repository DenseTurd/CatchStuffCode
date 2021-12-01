using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSlowmoTrigger : MonoBehaviour
{

    public float slow = 0.6f;
    public float duration;

    public void Update()
    {
        duration = Time.timeSinceLevelLoad / 50f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TimeControl.instance.SlowMo(slow, duration);
            Destroy(gameObject);
        }
    }
}
