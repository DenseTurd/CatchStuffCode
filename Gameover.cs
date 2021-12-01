using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scoreUI;
    public Text secondsSurvivedUI;
    bool gameOver;
    public string mode;

    private void Start()
    {
        ScoreControl.ResetScore();

        PlayerControllerBlochFall.Instance.OnPlayerDeath += OnGameOver;
    }

    public void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ScoreControl.ResetScore();
                SceneManager.LoadScene(mode);
            }
        }
    }
    void OnGameOver()
    {
        TimeControl.instance.modeSpeed = 1f;

        gameOverScreen.SetActive(true);
        Debug.Log(Time.timeSinceLevelLoad.ToString());
        secondsSurvivedUI.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        gameOver = true;

        ScoreControl.FixScore();
        if (Settings.hasAlteredSpeed == false)
        {
            ScoreControl.SetHighScore();
        }
        scoreUI.text = ScoreControl.GetScore().ToString();

        PlayerControllerBlochFall.Instance = null;

    }
}
