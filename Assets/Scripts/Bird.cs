using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public float speed;
    public GameObject endScreen;
    int score = 0;

    public GameObject flashEffect;

    public TextMeshPro scoreText;
    public AudioClip scoreSound;
    AudioSource source;
    public AudioClip hit;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = gameObject.AddComponent<AudioSource>();

        // Disable gravity and freeze rotation
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Enable gravity and allow rotation
            rb.gravityScale = 3;
            rb.freezeRotation = false;

            rb.velocity = Vector2.up * jumpSpeed;
            Pipe.speed = speed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;
        Invoke("ShowMenu", 1f);     // timer

        PlayerPrefs.SetInt("Score", score);
        flashEffect.SetActive(true);
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
        GetComponent<AudioSource>().PlayOneShot(hit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        source.clip = scoreSound;
        source.Play();
        scoreText.text = score.ToString();
    }
}

