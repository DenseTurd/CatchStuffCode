using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyShieldShieldControlR : MonoBehaviour
{
    public GameObject sploady;
    public GameObject pop;

    float screenHalfWidthInWorldUnits;
    float plyrPosY;
    void Start()
    {
        
        ShieldBurstControl.instance.AddSpringyShieldShieldR(gameObject);
    }

    void Update()
    {
        
        if (PlayerControllerBlochFall.Instance != null)
        {
            plyrPosY = PlayerControllerBlochFall.Instance.transform.position.y;
        }

        if (ShieldBurstControl.instance.springyR == true)
        {
            if (SpringyShieldControllerR.instance != null)
            {
                transform.position = new Vector2(SpringyShieldControllerR.instance.transform.position.x, (plyrPosY + 1.2f) + (ShieldBurstControl.instance.SpringyRListIndex(gameObject) / 1.5f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
        {
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ObsticleMovement>().Respawn();
            ShieldBurstControl.instance.RemoveSpringyShieldShieldR(gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<StuffMovement>().Respawn();
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            AudioManager.instance.Play("pop", Random.Range(0.4f, 1.5f));
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
            PlayerControllerBlochFall.Instance.Yay();
        }
    }



}