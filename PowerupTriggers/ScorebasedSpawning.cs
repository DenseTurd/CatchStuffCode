using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorebasedSpawning : MonoBehaviour
{


    bool spawnedLife1 = false;
    public GameObject life;
    public float scoreThresholdLife1 = 3000f;

    
    public GameObject PwrSploGun;
    public float scoreThresholdSploGun1 = 2000f;
    public float scoreDelaySploGun1 = 1234f;

    public GameObject ShieldBurst;
    public float scoreThresholdShieldBurst1 = 1000;

    public GameObject destroyer;
    public float nextDestroyer1;
    public float nextDestroyer2;
    public float nextDestroyer3;
    public float scoreThresholdDestroyer1 = 4000;
    public float scoreDelayDestroyer1 = 2000;

    public float scoreThresholdDestroyer2 = 17640;
    public float scoreDelayDestroyer2 = 8000;

    public float scoreThresholdDestroyer3 = 17640;
    public float scoreDelayDestroyer3 = 15000;

    void Update()
    {
        nextDestroyer1 = scoreDelayDestroyer1 + scoreThresholdDestroyer1;
        nextDestroyer2 = scoreThresholdDestroyer2 + scoreDelayDestroyer2;
        nextDestroyer3 = scoreThresholdDestroyer3 + scoreDelayDestroyer3;

        if (spawnedLife1 == false)
        {
            if (ScoreControl.GetScore() > scoreThresholdLife1)
            {
                Instantiate(life, new Vector3(0, Camera.main.orthographicSize), transform.rotation);
                spawnedLife1 = true;
            }
        }

       
        
            if (ScoreControl.GetScore() > scoreThresholdSploGun1 + scoreDelaySploGun1)
            {
                Instantiate(PwrSploGun, new Vector3(0, Camera.main.orthographicSize), transform.rotation);
                scoreThresholdSploGun1 += scoreThresholdSploGun1 * 2.2f;

            }

            if (ScoreControl.GetScore() > scoreThresholdShieldBurst1)
            {
            Instantiate(ShieldBurst, new Vector3(0, Camera.main.orthographicSize), transform.rotation);
            scoreThresholdShieldBurst1 += scoreThresholdShieldBurst1 * 2.2f;
            }

        if (ScoreControl.GetScore() > scoreThresholdDestroyer1 + scoreDelayDestroyer1)
        {
            Instantiate(destroyer, new Vector3(0, Camera.main.orthographicSize), transform.rotation);
            scoreThresholdDestroyer1 += scoreThresholdDestroyer1 * 1.1f;
        }
        if (ScoreControl.GetScore() > scoreThresholdDestroyer2 + scoreDelayDestroyer2)
        {
            Instantiate(destroyer, new Vector3(0, Camera.main.orthographicSize), transform.rotation);
            scoreThresholdDestroyer2 += scoreThresholdDestroyer2 * 1.1f;
        }
        if (ScoreControl.GetScore() > scoreThresholdDestroyer3 + scoreDelayDestroyer3)
        {
            Instantiate(destroyer, new Vector3(0, Camera.main.orthographicSize), transform.rotation);
            scoreThresholdDestroyer3 += scoreThresholdDestroyer3 * 1.1f;
        }

    }
}
