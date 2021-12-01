using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMovement : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed = 0.07f;
    float visibleHeightThreshold;

    Vector2 screenHalfSize;


    public float scoreValue;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDiffucultyPercentage());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y -3;

        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    
    void Update()
    {
        transform.Translate( new Vector2(0, -speed * Time.deltaTime));

        if (transform.position.y < visibleHeightThreshold)
        {
            ScoreControl.ChangeScore(-1);
            Destroy(gameObject);
        }
    }

   

    public float GetScoreValue()
    {
        return scoreValue;
    }
}
