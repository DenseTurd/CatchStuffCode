using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlockPlacer : MonoBehaviour
{
    public GameObject[] startingBlocks;
    Vector2 screenHalfSize;
    public float pitch = 0.4f;

    private void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        StartCoroutine(IntroBlockPlacing());
    }

    public IEnumerator IntroBlockPlacing()
    {

        foreach (GameObject block in startingBlocks)
        {
            block.transform.position = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), 2 + (Random.Range(-(screenHalfSize.y - 2), screenHalfSize.y - 2)));
            block.transform.localScale = Vector2.one * Random.Range(0.25f, 0.35f);
            block.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-20f, 20f));
            AudioManager.instance.Play("pop", pitch);
            pitch += 0.3f;
            yield return new WaitForSeconds(0.1f);
        }

      
    }
}
