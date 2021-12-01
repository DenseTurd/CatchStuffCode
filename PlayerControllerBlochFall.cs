using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBlochFall : MonoBehaviour
{
    public float speed = 15f;
    public float inputX;
    public float inputY;

    public event System.Action OnPlayerDeath;
    public GameObject sploady;

    float screenHalfWidthInWorldUnits;
    float fixedY;

    public bool isDestroyer;
    Renderer rend;
    public static PlayerControllerBlochFall Instance { get; set; }
    public float halfPlayerWidth;

    public Sprite regular;
    public Sprite ouch;
    public Sprite yay;
    public Sprite destroyer;
    public float returnToRegularSprite = 0.5f;
    float returnToRegularSpriteTime;

    SpriteRenderer spriteRenderer;
    public GameObject bidyGood;
    public GameObject bidyBad;
    public GameObject pop;
    public GameObject turning1;
    public GameObject turning2;
    public GameObject turning3;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }


        Instance = this;
    }
    void Start()
    {
        halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        fixedY = transform.position.y;
        rend = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (ScoreControl.bidy == true)
        {
            Instantiate(bidyGood, new Vector2(transform.position.x, transform.position.y + 20), transform.rotation);
            Instantiate(bidyBad, new Vector2(0, 20), transform.rotation);
        }

    }

    private void FixedUpdate()
    {
        if (isDestroyer)
        {
            spriteRenderer.sprite = destroyer;
        }
        else
        {
            if (spriteRenderer.sprite != regular)
            {
                if (Time.time > returnToRegularSpriteTime)
                {
                    spriteRenderer.sprite = regular;
                }
            }
        }

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Settings.accessiBearMode != 1)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchPosition.x > 4)
                {
                    inputX = 1;
                }
                else if (touchPosition.x < -4)
                {
                    inputX = -1;
                }
                else
                {
                    inputX = 0;
                }

                if (touchPosition.y > 3)
                {
                    inputY = 1;
                }
                else if (touchPosition.y < -3)
                {
                    inputY = -1;
                }
                else
                {
                    inputY = 0;
                }
            }
        }
        else
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");
        }

        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
        {
            Instantiate(sploady, collision.transform.position, collision.transform.rotation);

            if (isDestroyer == true)
            {
                if (collision.GetComponent<ObsticleMovement>().ObsticleNo == 1)
                {
                    Instantiate(turning1, collision.transform.position, collision.transform.rotation);
                }
                else if (collision.GetComponent<ObsticleMovement>().ObsticleNo == 2)
                {
                    Instantiate(turning2, collision.transform.position, collision.transform.rotation);
                }
                else if (collision.GetComponent<ObsticleMovement>().ObsticleNo == 3)
                {
                    Instantiate(turning3, collision.transform.position, collision.transform.rotation);
                }
                Destroy(collision.gameObject);
                spriteRenderer.sprite = regular;
                isDestroyer = false;
            }

            else
            {
                collision.GetComponent<ObsticleMovement>().Respawn();


                if (ScoreControl.GetLives() < 0.1)
                {
                    if (OnPlayerDeath != null)
                    {
                        Instance = null;
                        OnPlayerDeath();
                    }

                    transform.position = new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z);
                }
                else
                {
                    ScoreControl.ChangeLives(-1);
                    spriteRenderer.sprite = ouch;
                    returnToRegularSpriteTime = Time.time + returnToRegularSprite;
                }
            }
        }

        if (collision.tag == "GoodStuff")
        {
            Instantiate(pop, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<StuffMovement>().Respawn();
            ScoreControl.ChangeScore(collision.GetComponent<StuffMovement>().GetScoreValue());
            AudioManager.instance.Play("pop", Random.Range(0.6f, 1.8f));
            
        }

        if (collision.tag == "Powerup")
        {
            AudioManager.instance.Play("blip", Random.Range(0.8f, 1.4f));
            Yay();
        }

    }

    public void Yay()
    {
        spriteRenderer.sprite = yay;
        returnToRegularSpriteTime = Time.time + returnToRegularSprite;
    }
}
