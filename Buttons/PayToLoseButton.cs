using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PayToLoseButton : MonoBehaviour
{
   
    public void GoToAPIMenu()
    {
        SceneManager.LoadScene(2);
    }

}
