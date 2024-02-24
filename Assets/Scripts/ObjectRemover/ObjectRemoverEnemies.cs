using UnityEngine;

public class ObjectRemoverEnemies : ObjectRemover<Enemy>
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _pool.PutObject(enemy);
        }
    }
}
