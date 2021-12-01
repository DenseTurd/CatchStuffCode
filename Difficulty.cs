using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float secondsToMaxDifficulty = 300f;

    public static float GetDiffucultyPercentage()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
   
}
