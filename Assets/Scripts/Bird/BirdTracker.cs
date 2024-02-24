using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        FollowBird();
    }

    private void FollowBird()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;
        transform.position = position;
    }
}
