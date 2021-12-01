using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    public float enableSkipDelay = 6f;
    float enableSkipTime;
    public Button skip;

    void Start()
    {
        enableSkipTime = Time.time + enableSkipDelay;
    }

   
    void Update()
    {
        if(Time.time > enableSkipTime)
        {
            skip.gameObject.SetActive(true);
        }
    }
}
