﻿using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{ 
    public float speed = 1f;

    private Rigidbody2D body;
    private AudioSource hitAudio;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(body, "Failed to find RigidBody2D component.");
        hitAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameMode.instance.OnBallAdded();
    }

    private void OnDestroy()
    {
        GameMode.instance.OnBallRemoved();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = body.velocity.normalized;
        velocity *= speed;
        body.velocity = velocity;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitAudio.isPlaying)
        {
            hitAudio.Stop();
        }
        hitAudio.Play();
    }
}