﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed = 1f;
    public GameObject sploady;
    public GameObject pop;
   
    void Update()
    {
        transform.Translate(new Vector3(0, speed)); 
        if(transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "BadStuff")
        {
            ScoreControl.ChangeScore(11);
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ObsticleMovement>().Respawn();
            Destroy(gameObject);
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            collision.GetComponent<StuffMovement>().Respawn();
            AudioManager.instance.Play("pop", Random.Range(0.5f, 2f));
            Destroy(gameObject);
            
        }
    }
}
