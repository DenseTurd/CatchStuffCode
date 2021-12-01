using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   public void GoToMenu()
    {
        if (TimeControl.instance != null)
        {
            TimeControl.instance.Resume();
        }
        ScoreControl.ResetScore();
        SceneManager.LoadScene(0);
    }
}
