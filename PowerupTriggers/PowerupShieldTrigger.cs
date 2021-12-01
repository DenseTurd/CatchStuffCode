using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShieldTrigger : MonoBehaviour
{
    public GameObject shield;
    public GameObject springyShieldShieldL;
    public GameObject springyShieldShieldR;
    float vPos;
    float plrPosX;
    float plrPosY;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            plrPosX = PlayerControllerBlochFall.Instance.transform.position.x;
            plrPosY = PlayerControllerBlochFall.Instance.transform.position.y;
            vPos = ShieldBurstControl.instance.ListLenght();
            Vector2 spawnPosition = new Vector2(plrPosX, (plrPosY + 0.8f) + (vPos));

            
            
                if(ShieldBurstControl.instance.springyL == true)
                {
                    Instantiate(springyShieldShieldL, spawnPosition, Quaternion.Euler(Vector3.forward * 0));
                }

            if (ShieldBurstControl.instance.springyR == true)
            {
                Instantiate(springyShieldShieldR, spawnPosition, Quaternion.Euler(Vector3.forward * 0));
            }


            Instantiate(shield, spawnPosition, Quaternion.Euler(Vector3.forward * 0));
            Destroy(gameObject);
        }
    }
}
