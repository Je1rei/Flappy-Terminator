using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    private Queue <T> _pool;

    public IEnumerable<T> PooledObjects { get; private set; }

    protected void Awake()
    {
        _pool = new Queue<T>();
        PooledObjects = _pool;
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T newObject = Instantiate(_prefab);
            PutObject(newObject);
        }

        return _pool.Dequeue();
    }

    public void PutObject(T newObject)
    {
        _pool.Enqueue(newObject);
        newObject.gameObject.SetActive(false);
    }

    protected void Reset()
    {
        foreach(var obj in _pool)
        {
            Destroy(obj.gameObject);
        }

        _pool.Clear();
    }
}
