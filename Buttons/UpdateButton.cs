using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateButton : MonoBehaviour
{
    public Canvas updateWarningCanvas;
    public void UpdateApp()
    {
        Application.OpenURL("market://details?id=com.DenseTurd.CatchStuff");
        if (updateWarningCanvas != null)
        {
            updateWarningCanvas.gameObject.SetActive(false);
        }
        Application.Quit();
    }
}
