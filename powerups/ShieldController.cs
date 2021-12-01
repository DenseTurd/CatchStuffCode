using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float speed = 15f;
    public GameObject sploady;
    public GameObject pop;

    float screenHalfWidthInWorldUnits;
    void Start()
    {
        float halfPlayerWidth = PlayerControllerBlochFall.Instance.halfPlayerWidth;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        ShieldBurstControl.instance.AddShield(gameObject);
    }

    void Update()
    {
        float inputX = PlayerControllerBlochFall.Instance.inputX;
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (PlayerControllerBlochFall.Instance != null)
        {
            float plyrPosY = PlayerControllerBlochFall.Instance.transform.position.y;
            transform.position = new Vector2(transform.position.x, (plyrPosY + 1.2f) + (ShieldBurstControl.instance.ListIndex(gameObject) / 1.5f));
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
            AudioManager.instance.Play("pop", Random.Range(0.4f, 1.6f));
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
            PlayerControllerBlochFall.Instance.Yay();
        }
    }



}