using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuButton : MonoBehaviour
{
    public GameObject settingsMenu;
   public void OpenSettingsMenu()
    {
        settingsMenu.GetComponent<SettingsMenu>().OpenSettingsMenu();      
    }
}
