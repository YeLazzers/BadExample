using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter: MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _bulletSpeed;

    private WaitForSeconds _waitForSecondsToShoot;

    private void Start()
    {
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        while (enabled)
        {
            Vector3 direction = (_targetTransform.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.forward = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;

            yield return _waitForSecondsToShoot;
        }
    }
}