using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public float speed;
    public GameObject endScreen;
    int score = 0;
    int skin;
    int background;

    public GameObject yellowSkin;
    public GameObject blueSkin;
    public GameObject redSkin;

    public GameObject day;
    public GameObject night;


    public TextMeshPro scoreText;
    public AudioClip scoreSound;
    AudioSource source;
    Rigidbody2D rb;


    private void Start()
    {
        // skin
        yellowSkin.SetActive(false);
        blueSkin.SetActive(false);
        redSkin.SetActive(false);
        // background
        day.SetActive(false);
        night.SetActive(false);


        rb = GetComponent<Rigidbody2D>();
        source = gameObject.AddComponent<AudioSource>();
        Pipe.speed = speed;
        endScreen.SetActive(false);

        skin = Random.Range(1, 4);
        background = Random.Range(1, 3);

        if (skin == 1)
            yellowSkin.SetActive(true);

        if (skin == 2)
            blueSkin.SetActive(true);

        if (skin == 3)
            redSkin.SetActive(true);
        

        if (background == 1)
            day.SetActive(true);

        if (background == 2)
            night.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;
        Invoke("ShowMenu", 1f);

        //var sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneName);
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);

        scoreText.gameObject.SetActive(false);
        // scoreText.enabled = false;
        // scoreText.text = "";
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        source.clip = scoreSound;
        source.Play();
        scoreText.text = score.ToString();
    }
}

