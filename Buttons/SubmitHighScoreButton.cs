using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitHighScoreButton : MonoBehaviour
{
    public InputField nameField;
    public string userName;
    public Text txt;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }
    public void ActivatButton()
    {
        if(nameField.text != null)
        {
            button.interactable = true;
            Color txtColor = txt.color;
            txtColor.a = 255f;
            txt.color = txtColor;
        }
    }
    public void Submit()
    {
        if (PlayerPrefs.GetInt("SubmittedScore") == PlayerPrefs.GetInt("HighScore1"))
        {
            return;
        }
        else
        {
            userName = nameField.text;
            GlobalHighScores.instance.AddNewHighScore(userName, PlayerPrefs.GetInt("HighScore1"));

            PlayerPrefs.SetInt("SubmittedScore", PlayerPrefs.GetInt("HighScore1"));
        }
    }
}
