using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShieldControl : MonoBehaviour
{
    public float speed = 15f;
    public int dir = 0;
    public GameObject sploady;
    public GameObject pop;

    float screenHalfWidthInWorldUnits;
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

        if (dir == -1 )
        {
            speed *= 0.707f;
        }

        if (dir == 1)
        {
            speed *= 0.707f;
        }
    }

    void Update()
    {
        transform.Translate(new Vector2(dir * speed * Time.deltaTime, speed * Time.deltaTime));

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
        {
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ObsticleMovement>().Respawn();
            ShieldBurstControl.instance.RemoveShield(gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<StuffMovement>().Respawn();
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            AudioManager.instance.Play("pop", Random.Range(0.5f, 2f));
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
            PlayerControllerBlochFall.Instance.Yay();
        }
    }



}