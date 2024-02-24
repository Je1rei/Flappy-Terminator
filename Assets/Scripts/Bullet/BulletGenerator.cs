using System.Collections;
using UnityEngine;
using System;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private Transform _parentBullet;

    [SerializeField] private float _delay;
    [SerializeField, Range(-1, 1)] private int _directionX;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isActivatedClick = false;

    [SerializeField] private ObjectPoolBullet _pool;

    private Coroutine _currentCoroutine;
    private Enemy _enemy;
    private Bird _bird;

    private void Awake()
    {
        _enemy = _parentBullet.GetComponent<Enemy>();
        _bird = _parentBullet.GetComponent<Bird>();
    }

    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        if (_isActivatedClick == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Spawn();
            }
        }
    }

    private void Setup(Bullet bullet)
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPoint;

        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();

        if (rigidbodyBullet != null)
        {
            rigidbodyBullet.velocity = new Vector2(_speed * _directionX, 0f);
        }
    }

    private IEnumerator GenerateBullets()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        Bullet bullet = _pool.GetObject();
        SetLayer(bullet);
        Setup(bullet);
    }

    private void Generate()
    {
        if (_isActivatedClick == false)
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(GenerateBullets());
        }
    }

    private void SetLayer(Bullet bullet)
    {
        if (_enemy != null)
        {
            bullet.SetLayer(LayerMask.NameToLayer(bullet.LayerEnemyBullet));
        }
        else if (_bird != null)
        {
            bullet.SetLayer(LayerMask.NameToLayer(bullet.LayerBirdBullet));
        }
    }
}