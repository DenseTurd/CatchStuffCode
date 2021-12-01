using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreControl
{
    static int lives = 0;

    static int score = 0;
    static bool fixScore;
    public static bool bidy;
    static int[] highScore = new int[6];
    
public static void InitialiseHighScore()
    {
        highScore[0] = PlayerPrefs.GetInt("HighScore1", highScore[0]);
        highScore[1] = PlayerPrefs.GetInt("HighScore2", highScore[1]);
        highScore[2] = PlayerPrefs.GetInt("HighScore3", highScore[2]);
        highScore[3] = PlayerPrefs.GetInt("HighScore4", highScore[3]);
        highScore[4] = PlayerPrefs.GetInt("HighScore5", highScore[4]);
        highScore[5] = PlayerPrefs.GetInt("HighScore6", highScore[5]);
        
    }

    public static void ChangeLives(int lifeAdd)
    {
        if (fixScore == false)
        {
            lives += lifeAdd;
        }
        else
            return;
    }

    public static int GetLives()
    {
        return lives;

    }

    public static void ChangeScore(int scoreAdd)
    {
        if (fixScore == false)
        {
            score += scoreAdd;
        }
        else
            return;
    }

    public static int GetScore()
    {
        return score;

    }

    public static void ResetScore()
    {
        score = 0;
        lives = 0;
        fixScore = false;
    }

    public static void FixScore()
    {
        fixScore = true;
    }

    public static int SetHighScore()
    {
        int i = 0;
        //Look for the index to insert score
        while (i < highScore.Length)
        {
            if (highScore[i] <= score)
            {
                break;
            }
            i++;
        }
        //Score doesn't make it to top 10
        if (i >= highScore.Length)
        {
            return -1;
        }
        //Push all the scores not higher than score backward
        for (int j = highScore.Length - 1; j > i; --j)
        {
            highScore[j] = highScore[j - 1];
        }
        //Set score
        highScore[i] = score;

        PlayerPrefs.SetInt("HighScore6", highScore[5]);
        PlayerPrefs.SetInt("HighScore5", highScore[4]);
        PlayerPrefs.SetInt("HighScore4", highScore[3]);
        PlayerPrefs.SetInt("HighScore3", highScore[2]);
        PlayerPrefs.SetInt("HighScore2", highScore[1]);
        PlayerPrefs.SetInt("HighScore1", highScore[0]);

        return 1;
    }

    public static void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore6", 0);
        PlayerPrefs.SetInt("HighScore5", 0);
        PlayerPrefs.SetInt("HighScore4", 0);
        PlayerPrefs.SetInt("HighScore3", 0);
        PlayerPrefs.SetInt("HighScore2", 0);
        PlayerPrefs.SetInt("HighScore1", 0);
    }
}
