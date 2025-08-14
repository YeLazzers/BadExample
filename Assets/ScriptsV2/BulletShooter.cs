using System.Collections;
using UnityEngine;

public class BulletShooter: MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
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
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity)
                .Initialize(transform.position, (_target.position - transform.position).normalized, _bulletSpeed);


            yield return _waitForSecondsToShoot;
        }
    }
}