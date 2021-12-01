using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XShieldVertControl : MonoBehaviour
{
    float lives = 3f;
    public GameObject sploady;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
        {
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ObsticleMovement>().Respawn();
            lives += -1f;
            transform.localScale = Vector2.one * (0.3333f * lives);
        }

        if (collision.tag == "GoodStuff")
        {
            collision.GetComponent<StuffMovement>().Respawn();
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            AudioManager.instance.Play("pop", Random.Range(0.5f, 2f));
        }

        if (lives < 1f)
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
        }
    }
}
