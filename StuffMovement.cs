using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffMovement : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed = 0.07f;
    float visibleHeightThreshold;

    Vector2 screenHalfSize;

    public float respawnAngleMax;
    public Vector2 respawnSizeMinMax;

    public int scoreValue;
    public GameObject sploady;

    float startDelay = 0.8f;
    public float turnedDelay;

    SpriteRenderer spriteRenderer;

    bool active;
    CircleCollider2D circleCollider;
   
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDiffucultyPercentage());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;

        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));

        circleCollider = GetComponent<CircleCollider2D>();
    }

    
    void Update()
    {
        if (active == false)
        {

            if (Time.timeSinceLevelLoad > startDelay)
            {
                if (Time.time > turnedDelay)
                {
                    circleCollider.isTrigger = true;
                    active = true;
                }
            }
        }
        else
        {
            transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }

        if (transform.position.y + 1.3f < visibleHeightThreshold)
        {
            Respawn();

             if(PlayerControllerBlochFall.Instance != null)
            { 
                if (PlayerControllerBlochFall.Instance.isDestroyer == true)
                 {
                ScoreControl.ChangeScore(1);
                }
                 else
                {
                ScoreControl.ChangeScore(-1);
                }
            }
        }
    }

    public void Respawn()
    {
        float respawnAngle = UnityEngine.Random.Range(-respawnAngleMax, respawnAngleMax);
        float respawnSize = UnityEngine.Random.Range(respawnSizeMinMax.x, respawnSizeMinMax.y);
        Vector2 respawnLocation = new Vector2(UnityEngine.Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + (respawnSize * 9f));
        transform.SetPositionAndRotation(respawnLocation, Quaternion.Euler(Vector3.forward * respawnAngle));
        transform.localScale = Vector2.one * respawnSize;
        spriteRenderer.flipX = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
        spriteRenderer.sortingOrder = 1;
    }

    public int GetScoreValue()
    {
        return scoreValue;
    }

  
}
