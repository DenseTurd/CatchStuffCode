using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OkLetsGoButton : MonoBehaviour
{
   public void OKLetsGo()
    {
        PlayerPrefs.SetInt("TutorialDone", 1);
        SceneManager.LoadScene(1);
    }
}
