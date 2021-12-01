using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GlobalHighScores : MonoBehaviour
{
    const string privateCode = "AQGZ892cYEWYI8gfHl0akgc6jAd43oB0S6kiD-3Yp39w";
    const string publicCode = "5da0d3e5d1041303ec52f0ac";
    const string webURL = "http://dreamlo.com/lb/";

    public GlobalHighScore[] globalHighScores;
    DisplayGlobalHighScores globalHighScoresDisplay;
    public static GlobalHighScores instance;

    private void Awake()
    {
       // AddNewHighScore("Strong", 20000);
       // AddNewHighScore("Back", 15000);
       // AddNewHighScore("Flat", 10000);
       // AddNewHighScore("Patch", 5000);
       // AddNewHighScore("Head", 1000);
        instance = this;
        globalHighScoresDisplay = GetComponent<DisplayGlobalHighScores>();
    }
    public void AddNewHighScore(string name, int score)
    {
        StartCoroutine(UploadHighScore(name, score));
    }
    IEnumerator UploadHighScore(string name, int score)
    {
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(name) + "/" + score);
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successful");
            RequestGlobalHighScore();
        }
        else
        {
            Debug.Log("Upload failed " + www.error);
        }

    }

    public void RequestGlobalHighScore()
    {
        StartCoroutine(DownloadHighScores());
    }

    IEnumerator DownloadHighScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/pipe/5");
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
           FormatHighScores(www.downloadHandler.text);
            globalHighScoresDisplay.OnHighScoresDownloaded(globalHighScores);
        }
        else
        {
            Debug.Log("Download failed " + www.error);
        }


    }
     void FormatHighScores(string textStream)
     {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        globalHighScores = new GlobalHighScore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string name = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            globalHighScores[i] = new GlobalHighScore(name, score);
          //  print(globalHighScores[i].name + " : " + globalHighScores[i].score);
        }
     }
}

public struct GlobalHighScore
{
    public string name;
    public int score;

    public GlobalHighScore(string _name, int _score)
    {
        name = _name;
        score = _score;
    }
}
