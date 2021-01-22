using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    private static readonly float startEnemyFallSpeed = 1f;
    private static float enemyFallSpeed;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float timeBetweenSpeedIncrease = 5f;
    private float timer;

    private void Start()
    {
        enemyFallSpeed = startEnemyFallSpeed;
        timer = timeBetweenSpeedIncrease;
    }

    public static float CurrentSpeed()
    {
        var speed = enemyFallSpeed;

        return speed;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            enemyFallSpeed += speedIncrease;
            timer = timeBetweenSpeedIncrease;
        }
    }
}
