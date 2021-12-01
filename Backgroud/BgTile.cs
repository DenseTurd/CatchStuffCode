using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTile : MonoBehaviour
{

    float screenHalfWidthPlusTile;
    float screenHalfHeightPlusTile;
    float tileWidth;
    float tileHeight;

    SpriteRenderer rendy;
   
    void Start()
    {
        rendy = gameObject.GetComponent<SpriteRenderer>();
        tileWidth = rendy.size.x;
        tileHeight = rendy.size.y;
        screenHalfWidthPlusTile = Camera.main.aspect * Camera.main.orthographicSize + tileWidth;
        screenHalfHeightPlusTile = Camera.main.orthographicSize + tileHeight;
    }

    void Update()
    {
        transform.Translate(BackgroundControl.instance.hSpeed, BackgroundControl.instance.vSpeed, 0);

        if (transform.position.x > screenHalfWidthPlusTile)
        {
            transform.position = new Vector3(-screenHalfWidthPlusTile, transform.position.y, 10f);
        }

        if (transform.position.y > screenHalfHeightPlusTile)
        {
            transform.position = new Vector3(transform.position.x, -screenHalfHeightPlusTile, 10f);
        }

        if (transform.position.x < -screenHalfWidthPlusTile)
        {
            transform.position = new Vector3(screenHalfWidthPlusTile, transform.position.y, 10f);
        }

        if (transform.position.y < -screenHalfHeightPlusTile)
        {
            transform.position = new Vector3(transform.position.x, screenHalfHeightPlusTile, 10f);
        }
    }
}
