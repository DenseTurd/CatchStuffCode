using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MegaModeButton : MonoBehaviour
{
   public void GoToMegaMode()
    {
        SceneManager.LoadScene(4);
    }
}
