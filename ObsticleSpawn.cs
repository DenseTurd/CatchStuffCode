using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawn : MonoBehaviour
{
    float spawnTime;
    public float spawnDelay;
    public Vector2 secondsBetweenSpawnsMinMax;

    public GameObject obstica;
    Vector2 screenHalfSize;

    public float spawnAngleMax;
    
    public Vector2 spawnSizeMinMax;

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
            Vector2 spawnLocation = new Vector3(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize + 3, -5);
           GameObject newSpawn = (GameObject)Instantiate(obstica, spawnLocation, Quaternion.Euler(Vector3.forward* spawnAngle));
            newSpawn.transform.localScale = Vector2.one * spawnSize;

            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDiffucultyPercentage());
            spawnTime = Time.time + secondsBetweenSpawns;
          
        }
    }
}
