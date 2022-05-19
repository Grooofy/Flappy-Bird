﻿using System;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out ScoreZone scoreZone))
            _bird.IncreaseScore();
        else
            _bird.Die();
    }
}