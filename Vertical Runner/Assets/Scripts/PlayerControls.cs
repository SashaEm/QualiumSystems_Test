using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float halfScreen;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject restartScreen;
    [SerializeField] private GameSpeedManager gameSpeedManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private ScoreManager scoreManager;

    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        halfScreen = Screen.width / 2;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.position.x < halfScreen)
            {
                transform.position += new Vector3(-1f * moveSpeed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                transform.position += new Vector3(1f * moveSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            SetLoseAnim();
            enabled = false;
        }
    }

    void SetLoseAnim()
    {
        Animator.SetBool("isLost", true);
    }

    public void Lose()
    {
        scoreManager.SaveScore();
        restartScreen.SetActive(true);
        spawnManager.enabled = false;
        gameSpeedManager.enabled = false;
    }
}
