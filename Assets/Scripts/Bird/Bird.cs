﻿using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(Score), typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private Score _score;
    private BirdCollisionHandler _handler;

    public event Action GameOver;

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _score = GetComponent<Score>();
        _handler = GetComponent<BirdCollisionHandler>();
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Bullet bullet)
        {
            bullet = (Bullet)interactable;

            if (bullet != null && LayerMask.LayerToName(bullet.gameObject.layer) == bullet.LayerEnemyBullet)
            {
                GameOver?.Invoke();
            }
        }
    }

    public void Reset()
    {
        _score.Reset();
        _mover.Reset();
    }
}