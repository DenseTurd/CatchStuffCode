using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Canvas settingsCanvas;
    public AudioMixer audioMixer;

    public Toggle accessiBearMode;
    public Toggle accessiBearSpeed;
    public Toggle colorBlind;
    public Slider volSlider;
    public Toggle tutorial;

    private void Start()
    {
        SetSettingsUI();
    }

    public void tutorialToggle(bool tut)
    {
        if (tut == true)
        {   
            PlayerPrefs.SetInt("TutorialDone", 0);  
        }
        else
        {
            PlayerPrefs.SetInt("TutorialDone", 1);
        }
    }

    public void OpenSettingsMenu()
    {
        settingsCanvas.gameObject.SetActive(true);
        SetSettingsUI();
    }

    public void AccessiBearModeToggle()
    {
        if (accessiBearMode.isOn == true)
        {
            Settings.AccessiBearModeOn();
        }
        else
        {
            Settings.AccessiBearModeOff();
        }
        
    }

    public void AccessiBearSpeedToggle()
    {
        if (accessiBearSpeed.isOn == true)
        {
            Settings.AccessiBearSpeedOn();
            Settings.AccessiBearModeOn();
            SetSettingsUI();
        }
        else
        {
            Settings.AccessiBearSpeedOff();
        }
        
    }

    public void ColorBlindToggle()
    {
        if(colorBlind.isOn == true)
        {
            Settings.ColorBlindOn();
        }
        else
        {
            Settings.ColorBlindOff();
        }
    }

    public void Volume(float vol)
    {
        audioMixer.SetFloat("mainMix", vol);
       Settings.Volume(vol);
    }

    public void SetSettingsUI()
    {
        bool abm;
            if (Settings.accessiBearMode == 0)
            {
            abm = false;
            }
            else
            {
            abm = true;
            }
        accessiBearMode.isOn = abm;

        bool abs;
        if (Settings.accessiBearSpeed == 0)
        {
            abs = false;
        }
        else
        {
            abs = true;
        }
        accessiBearSpeed.isOn = abs;

        bool cb;
        if(Settings.colorblind == 0)
        {
            cb = false;
        }
        else
        {
            cb = true;
        }
        colorBlind.isOn = cb;

        if (PlayerPrefs.GetInt("TutorialDone") == 0)
        {
            tutorial.isOn = true;
        }
        else
        {
            tutorial.isOn = false;
        }

           volSlider.value = Settings.volume;
    }
}
