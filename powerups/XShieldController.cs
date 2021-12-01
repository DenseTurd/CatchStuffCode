using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XShieldController : MonoBehaviour
{
    public float speed = 15f;
    public GameObject sploady;
    public GameObject pop;

    float screenHalfWidthInWorldUnits;
    public float lives = 3f;
    void Start()
    {
        float halfPlayerWidth = PlayerControllerBlochFall.Instance.halfPlayerWidth;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        ShieldBurstControl.instance.AddXShield(gameObject);
    }

    void Update()
    {
        float inputX = PlayerControllerBlochFall.Instance.inputX;
        float velocityX = inputX * speed;
        transform.Translate(Vector2.right * velocityX * Time.deltaTime);

        float inputY = PlayerControllerBlochFall.Instance.inputY;
        float velocityY = inputY * speed;
        transform.Translate(Vector2.up * velocityY * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
        {
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ObsticleMovement>().Respawn();
            lives += -1f;
            transform.localScale = Vector2.one * (0.0444f * lives);
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<StuffMovement>().Respawn();
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            AudioManager.instance.Play("pop", Random.Range(0.5f, 2f));
        }

        if (lives < 1f)
        {
            ShieldBurstControl.instance.RemoveXShield(gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
            PlayerControllerBlochFall.Instance.Yay();
        }
    }



}