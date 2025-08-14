using System.Collections;
using UnityEngine;

public class BulletShooter: MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _bulletSpeed;

    private WaitForSeconds _waitForSecondsToShoot;

    private void Awake()
    {
        _waitForSecondsToShoot = _attackRate != 0 ? new WaitForSeconds(1 / _attackRate) : null;
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bulletRigidBody = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bulletRigidBody.transform.forward = direction;
            bulletRigidBody.velocity = direction * _bulletSpeed;

            yield return _waitForSecondsToShoot;
        }
    }
}