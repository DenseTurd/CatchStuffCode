using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static int accessiBear = PlayerPrefs.GetInt("accessiBear");
    public static int colorblind = PlayerPrefs.GetInt("colorBlind");
    public static int accessiBearSpeed = PlayerPrefs.GetInt("accessiBearSpeed");
    public static int accessiBearMode = PlayerPrefs.GetInt("accessiBearMode");
    public static float volume = PlayerPrefs.GetFloat("Volume");
    public static bool hasAlteredSpeed;
    public static void AccessiBearModeOn()
    {
        PlayerPrefs.SetInt("accessiBearMode", 1);
        accessiBearMode = 1;
    }
    public static void AccessiBearModeOff()
    {
        PlayerPrefs.SetInt("accessiBearMode", 0);
        accessiBearMode = 0;
    }

    public static void AccessiBearSpeedOn()
    {
        PlayerPrefs.SetInt("accessiBearSpeed", 1);
        accessiBearSpeed= 1;
        if (TimeControl.instance != null)
        {
            TimeControl.instance.SetSpeed();
        }
        hasAlteredSpeed = true;
    }
    public static void AccessiBearSpeedOff()
    {
        PlayerPrefs.SetInt("accessiBearSpeed", 0);
        accessiBearSpeed = 0;

        if (TimeControl.instance != null)
        {
            TimeControl.instance.SetSpeed();
        }
        
    }

    public static void ColorBlindOn()
    {
        PlayerPrefs.SetInt("colorBlind", 1);
        colorblind = 1;
    }
    public static void ColorBlindOff()
    {
        PlayerPrefs.SetInt("colorBlind", 0);
        colorblind = 0;
    }

    public static void Volume(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
        volume = vol;
    }

}
