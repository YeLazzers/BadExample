using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private Transform _projectilePoint;

    // TODO: Add ObjectPool

    public Projectile Spawn(Transform target)
    {
        Vector3 targetCenterCollider = target.GetComponent<Collider>().bounds.center;

        return Instantiate(_projectilePrefab, _projectilePoint.position, Quaternion.identity)
            .Initialize((targetCenterCollider - _projectilePoint.position).normalized, _projectileSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_projectilePoint.position, 0.1f);
    }
}
