using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sploady : MonoBehaviour
{
    public GameObject sploady;
    public GameObject pop;
    public float lifespan = 0.1f;
    float killTime;
    CameraShake cameraShake;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        AudioManager.instance.Play("boom", UnityEngine.Random.Range(0.5f, 1f));

        killTime = Time.time + lifespan;

        Physics.IgnoreLayerCollision(8, 8, true);

        cameraShake = Camera.main.GetComponent<CameraShake>();
        cameraShake.CamShake(0.1f, 0.07f);

        float respawnAngle = UnityEngine.Random.Range(0, 359);
        transform.localRotation = Quaternion.Euler(Vector3.forward * respawnAngle);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
    }
   

    private void Update()
    {
        if(Time.time > killTime)
        {
            Destroy(gameObject);
        }

        if(transform.position.y > Camera.main.orthographicSize)
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
            return;
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            collision.GetComponent<StuffMovement>().Respawn();
            AudioManager.instance.Play("pop", UnityEngine.Random.Range(0.5f, 2f));
            return;
        }
    }
}
