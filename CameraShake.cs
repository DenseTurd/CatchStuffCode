using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

   public float currentMagnitude = 0f;
    public float currentDuration = 0f;
    public float elapsed;
    Vector3 originalPos;
    public string sceneName;
    Vector3 bgColor;
    float H;
    float S;
    float V;

    private void Start()
    {
        originalPos = transform.position;
        Debug.Log(sceneName);
    }

    public void CamShake(float duration, float magnitude)
    {
       
            StartCoroutine(Shake(duration, magnitude));
        
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        
            elapsed = 0.0f;
 

        currentMagnitude += magnitude;
        currentDuration += duration;
         
        while (elapsed < currentDuration)
        {
            float x = Random.Range(-1f, 1f) * currentMagnitude;
            float y = Random.Range(-1f, 1f) * currentMagnitude;

            transform.localPosition = new Vector3(x, y, transform.position.z);
            elapsed += Time.deltaTime;

            yield return null;
        }
        
        if (elapsed >= currentDuration)
        {
            currentDuration = 0f;
            currentMagnitude = 0f;

        }
        transform.position = originalPos;
        
    }

   

    public void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            transform.position = originalPos;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //ScoreControl.ResetHighScore();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.SetInt("TutorialDone", 0);
        }
        
         Color.RGBToHSV(Camera.main.backgroundColor, out H, out S, out V);
        H -= 0.002f * Time.deltaTime;
        Camera.main.backgroundColor = Color.HSVToRGB(H, S, V);
    }

}
