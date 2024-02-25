using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;

    public event Action<int> Changed;

    public void Add()
    {
        _score++;
        Changed?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }
}

