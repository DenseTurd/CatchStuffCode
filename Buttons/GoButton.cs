using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoButton : MonoBehaviour
{
    public void Go()
    {
        int payedToLose = PlayerPrefs.GetInt("payedToLose"); 
        if (PlayerPrefs.GetInt("TutorialDone") == 0)
        {
            SceneManager.LoadScene(5);
        }
        else if (payedToLose == 1)
        {
            SceneManager.LoadScene(3);
        }
        else { SceneManager.LoadScene(1); }
    }
}
