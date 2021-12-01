using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public bool gameIsPaused = false;
    public float gameSpeed = 1f;
    public float modeSpeed = 1f;
    float prevSpeed;
    public float regularSpeedTime;
    public bool gameIsSlow = false;
    public float currentSpeed;

    public GameObject pauseMenuCanvas;

    float lerp = 0f;

    public static TimeControl instance { get; set; }

    private void Awake()
    {
        SetSpeed();
        Time.timeScale = modeSpeed;
        instance = this;
        if (Settings.accessiBearSpeed == 0)
        {
             Settings.hasAlteredSpeed = false;
        }

    }

    public void SetSpeed()
    {
        if (Settings.accessiBearSpeed == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "MegaMode")
            {
                modeSpeed = 1.3f;
                Debug.Log("faster");
            }
            else
            {
                modeSpeed = 1f;
            }

            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            modeSpeed = 0.8f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("backspace") || Input.GetKeyDown("f10")) 
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (gameIsPaused == false)
        {
            if (gameIsSlow)
            {
                Time.timeScale = Mathf.Lerp(modeSpeed, gameSpeed, lerp);
                lerp += 1.5f * Time.deltaTime;


                if (Time.time > regularSpeedTime)
                {
                    prevSpeed = gameSpeed;
                    gameSpeed = modeSpeed;
                    gameIsSlow = false;
                }
            }

            if (gameIsSlow == false)
            {
                if (lerp > 1f)
                {
                    lerp = 1f;
                }
                Time.timeScale = Mathf.Lerp(modeSpeed, prevSpeed, lerp);
                lerp -= 1.5f * Time.deltaTime;
            }
        }
        currentSpeed = Time.timeScale;

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenuCanvas.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = modeSpeed;
        gameIsPaused = false;
        pauseMenuCanvas.SetActive(false);
    }

    public void SlowMo(float speed, float duration)
    {
        gameSpeed = speed;
        regularSpeedTime = Time.time + duration;
        gameIsSlow = true;
        lerp = 0f;
        
    }
}
