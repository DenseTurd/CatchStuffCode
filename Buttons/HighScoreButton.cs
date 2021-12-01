using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreButton : MonoBehaviour
{
    public GameObject canvas;

    public void OpenHighScores()
    {
        canvas.SetActive(true);
    }
}
