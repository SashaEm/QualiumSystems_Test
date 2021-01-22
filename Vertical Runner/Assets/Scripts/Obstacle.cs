using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private float speed;


    private void Awake()
    {
        speed = GameSpeedManager.CurrentSpeed();
        SetupParticle();
    }

    private void Update()
    {
        transform.position -= new Vector3(0f, 1f * speed * Time.deltaTime, 0f);
    }

    void SetupParticle()
    {
        var particlesMain = particles.main;
        particlesMain.startLifetime = 5f / speed;
    }
}
