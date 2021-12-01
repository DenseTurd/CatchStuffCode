using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessiBearControl : MonoBehaviour
{
    public Canvas accesssiBearCanvas;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Settings.accessiBearMode == 0)
            {
                Settings.AccessiBearModeOn();
            }
            else
            {
                Settings.AccessiBearModeOff();
            }
        }

        if (Settings.accessiBearMode == 1)
        {
            accesssiBearCanvas.gameObject.SetActive(true);
        }
        else
        {
            accesssiBearCanvas.gameObject.SetActive(false);
        }
    }


}
