using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    private Vector3 _direction;
    private float _movementSpeed;

    public UnityAction<Player> TargetReached;

    public Projectile Initialize(Vector3 direction, float speed)
    {
        _direction = direction;
        _movementSpeed = speed;

        return this;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player enemy))
        {
            TargetReached?.Invoke(enemy);
        }
        Destroy(gameObject);
    }
}
