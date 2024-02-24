using UnityEngine;

public abstract class ObjectRemover<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected ObjectPool<T> _pool;
}