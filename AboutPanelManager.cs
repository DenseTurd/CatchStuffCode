using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanelManager : MonoBehaviour
{
    public GameObject[] panels;
    public int activePanel = 0;
    public GameObject mainMenu;
    public GameObject aboutSection;
    public void NextPanel()
    {
        activePanel++;
        foreach (GameObject panel in panels)
        {
            if (System.Array.IndexOf(panels, panel) != activePanel)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
        
    }

    public void PreviousPanel()
    {
        activePanel--;
        foreach (GameObject panel in panels)
        {
            if (System.Array.IndexOf(panels, panel) != activePanel)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
        
    }

    public void ClosePanel()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        mainMenu.SetActive(true);
        aboutSection.SetActive(false);
        activePanel = 0;
    }

    public void AboutSectionActivate()
    {
        aboutSection.SetActive(true);
        mainMenu.SetActive(false);
        panels[0].SetActive(true);
      //  NextPanel();
    }
}
