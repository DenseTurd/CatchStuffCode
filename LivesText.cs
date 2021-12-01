using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{
    public Text livesText;

    
    void Update()
    {
        livesText.text = ScoreControl.GetLives().ToString();
    }
}
