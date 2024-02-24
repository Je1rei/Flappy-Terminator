using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    private const string _layerBirdBullet = "BirdBullet";
    private const string _layerEnemyBullet = "EnemyBullet";

    public LayerMask Layer => gameObject.layer;
    public string LayerBirdBullet => _layerBirdBullet;
    public string LayerEnemyBullet => _layerEnemyBullet;

    public void SetLayer(LayerMask newlayer) => gameObject.layer = newlayer;
}
