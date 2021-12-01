using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpringyShieldTrigger : MonoBehaviour
{
    public GameObject springyShieldL;
    public GameObject springyShieldR;
    float plrPosX;
    float plrPosY;
    Vector3 spawnPosition;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            if (PlayerControllerBlochFall.Instance != null)
            {
                plrPosX = PlayerControllerBlochFall.Instance.transform.position.x;
                plrPosY = PlayerControllerBlochFall.Instance.transform.position.y;
                Vector3 spawnPosition = new Vector3(plrPosX, plrPosY + 0.25f, 1f);


                if (ShieldBurstControl.instance.springyL == false)
                {
                    Instantiate(springyShieldL, spawnPosition, Quaternion.Euler(Vector3.forward * 0));
                }

                if (ShieldBurstControl.instance.springyR == false)
                {
                    Instantiate(springyShieldR, spawnPosition, Quaternion.Euler(Vector3.forward * 0));
                }
            }
            Destroy(gameObject);
        }
    }
}
