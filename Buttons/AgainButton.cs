using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainButton : MonoBehaviour
{
    public string mode;
   public void Again()
    {
        SceneManager.LoadScene(mode);
    }
}
