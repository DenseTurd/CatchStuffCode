using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawn : MonoBehaviour
{
    float spawnTime;
    public float spawnDelay;
    public Vector2 secondsBetweenSpawnsMinMax;


    public GameObject goodStuff;
    Vector2 screenHalfSize;

    public float spawnAngleMax;
    
    public Vector2 spawnSizeMinMax;

    public float depth = 0f;

    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        spawnTime = Time.time + spawnDelay + Random.Range(0.3f, 1.6f);
        
    }

  
    void Update()
    {
        if (Time.time > spawnTime)
        {
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector3 spawnLocation = new Vector3(Random.Range(-(screenHalfSize.x -6), (screenHalfSize.x -6)), (screenHalfSize.y + spawnSize + 3), depth);
           GameObject newSpawn = (GameObject)Instantiate(goodStuff, spawnLocation, Quaternion.Euler(Vector3.forward* spawnAngle));
            newSpawn.transform.localScale = Vector2.one * spawnSize;

            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDiffucultyPercentage());
            spawnTime = Time.time + secondsBetweenSpawns;
          
        }
    }
}
