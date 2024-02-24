using System;
using UnityEngine;

[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour, IInteractable
{
    private EnemyCollisionHandler _handler;

    public event Action EnemyDead;

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void Awake()
    {
        _handler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Bullet bullet)
        {
            if (bullet != null && LayerMask.LayerToName(bullet.gameObject.layer) == bullet.LayerBirdBullet)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        EnemyDead?.Invoke();
        Destroy(gameObject);
    }
}