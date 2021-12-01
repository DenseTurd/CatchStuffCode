using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyShieldControllerR : MonoBehaviour
{

    public float offset = 4f;
    public float accel = 10f;

    public GameObject sploady;
    public GameObject springyShieldShieldR;
    public GameObject pop;

    float offsetDist;

    public static SpringyShieldControllerR instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {

            Destroy(gameObject);

        }


        instance = this;
    }

    private void Start()
    {
        ShieldBurstControl.instance.AddSpringyShield(gameObject);
        ShieldBurstControl.instance.springyR = true;
        foreach (GameObject s in ShieldBurstControl.instance.shields)
        {
            Instantiate(springyShieldShieldR, Camera.main.transform);

        }
    }

    void Update()
    {
        if (PlayerControllerBlochFall.Instance != null)
        {
            offsetDist = transform.position.x - (PlayerControllerBlochFall.Instance.transform.position.x + offset);
        }
        float velocity = offsetDist * -accel;

        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
        {
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<ObsticleMovement>().Respawn();
            ShieldBurstControl.instance.RemoveSpringyShield(gameObject);
            ShieldBurstControl.instance.springyR = false;
            ShieldBurstControl.instance.springyShieldShieldsR.Clear();
            instance = null;
            Destroy(gameObject);
            Destroy(this);
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<StuffMovement>().Respawn();
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            AudioManager.instance.Play("pop", Random.Range(0.5f, 1.6f));
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
            PlayerControllerBlochFall.Instance.Yay();
        }
    }
}
