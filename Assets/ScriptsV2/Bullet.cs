using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet: MonoBehaviour
{
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public Bullet Initialize(Vector3 position, Vector3 direction, float speed)
    {
        transform.position = position;

        _rigidBody.transform.forward = direction;
        _rigidBody.velocity = direction * speed;

        return this;
    }
}