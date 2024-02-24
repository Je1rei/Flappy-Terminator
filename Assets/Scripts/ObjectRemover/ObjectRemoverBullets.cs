using UnityEngine;

public class ObjectRemoverBullets : ObjectRemover<Bullet>
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _pool.PutObject(bullet);
        }
    }
}
