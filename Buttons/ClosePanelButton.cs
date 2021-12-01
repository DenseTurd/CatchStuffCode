using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject canvas;
    public void ClosePanel()
    {
        canvas.SetActive(false); 
    }
}
