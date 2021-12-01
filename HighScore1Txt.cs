using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore1Txt : MonoBehaviour
{

    public Text HighScoreText;
    public string HighScore123;
    void Update()
    {
        HighScoreText.text = PlayerPrefs.GetInt(HighScore123).ToString();
    }
}
