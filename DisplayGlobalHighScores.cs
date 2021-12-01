using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGlobalHighScores : MonoBehaviour
{
    public Text[] GScoreText;
    public Text[] GNameText;
    GlobalHighScores GlobalHighScoreManager;

    private void Start()
    {
        for( int i = 0; i < GScoreText.Length; i++)
        {
            GScoreText[i].text ="Fetching";
        }
        for (int i = 0; i < GNameText.Length; i++)
        {
            GNameText[i].text = "Fetching";
        }
        GlobalHighScoreManager = GetComponent<GlobalHighScores>();

        StartCoroutine("RefreshGlobalHighScores");
    }
    public void OnHighScoresDownloaded(GlobalHighScore[] scores)
    {
        for (int i = 0; i < GScoreText.Length; i++)
        {
            GScoreText[i].text = scores[i].score.ToString();
        }
        for (int i = 0; i < GNameText.Length; i++)
        {
            GNameText[i].text = scores[i].name;
        }
    }
    
    IEnumerator RefreshGlobalHighScores()
    {
        while (true)
        {
            GlobalHighScoreManager.RequestGlobalHighScore();
            yield return new WaitForSeconds(15f);
        }
    }
}
