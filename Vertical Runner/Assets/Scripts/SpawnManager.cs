using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Sprite[] obstacleSprites;
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private float startTimeBetweenObstacles = 2f;
    [SerializeField] private float minimalTimeBetweenObstacles = 0.8f;
    [SerializeField] private float spawnRateIncreaseTime = 1f;
    private float timeBetweenObstacles;
    private float timer;
    private Vector2 spawnBorders;

    private void Awake()
    {
        spawnBorders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        timeBetweenObstacles = startTimeBetweenObstacles;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenObstacles)
        {
            if(timeBetweenObstacles > minimalTimeBetweenObstacles)
            {
                timeBetweenObstacles -= spawnRateIncreaseTime * 0.01f;
            }

            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        var position = GenerateRandomPosition();
        var obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        var obstacleSprite = obstacle.GetComponent<SpriteRenderer>();
        SetObstacleVisual(obstacleSprite);
    }

    Vector3 GenerateRandomPosition()
    {
        var xPosition = Random.Range(-spawnBorders.x, spawnBorders.x);
        var yPosition = spawnBorders.y + 2f;
        var pos = new Vector3(xPosition, yPosition, 0f);
        return pos;
    }

    void SetObstacleVisual(SpriteRenderer spriteRenderer)
    {
        var randomSprite = obstacleSprites[Random.Range(0, obstacleSprites.Length)];
        spriteRenderer.sprite = randomSprite;
    }
}
