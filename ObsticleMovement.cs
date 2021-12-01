using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleMovement : MonoBehaviour
{
    public int ObsticleNo;
    public Vector2 speedMinMax;
    float speed = 0.07f;
    float visibleHeightThreshold;

    Vector2 screenHalfSize;

    public float respawnAngleMax;
    public Vector2 respawnSizeMinMax;
    public GameObject sploady;

    SpriteRenderer spriteRenderer;
    public Sprite reg;
    public Sprite colorBlind;

    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDiffucultyPercentage());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;

        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Settings.colorblind == 1)
        {
            spriteRenderer.sprite = colorBlind;
        }
        else
        {
            spriteRenderer.sprite = reg;
        }
        
        spriteRenderer.flipX = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
    }

    
    void Update()
    {
        transform.Translate( new Vector2(0, -speed * Time.deltaTime));

        if (transform.position.y +1.5f < visibleHeightThreshold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        float respawnAngle = UnityEngine.Random.Range(-respawnAngleMax, respawnAngleMax);
        float respawnSize = UnityEngine.Random.Range(respawnSizeMinMax.x, respawnSizeMinMax.y);
        Vector3 respawnLocation = new Vector3(UnityEngine.Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + (respawnSize * 9f + 5f), -5);
        transform.SetPositionAndRotation(respawnLocation, Quaternion.Euler(Vector3.forward * respawnAngle));
        transform.localScale = Vector2.one * respawnSize;
        if (Settings.colorblind == 1)
        {
            spriteRenderer.sprite = colorBlind;
        }
        else
        {
            spriteRenderer.sprite = reg;
        }
    }

   


}
