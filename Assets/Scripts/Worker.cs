using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ProjectileSpawner))]
public class Worker : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private List<Transform> _waypoints;
    
    private ProjectileSpawner _projectileSpawner;
    private PatrolMover _patrolMover;

    private void Awake()
    {
        _projectileSpawner = GetComponent<ProjectileSpawner>();
        _patrolMover = new PatrolMover(transform, _movementSpeed);
        _patrolMover.SetWaypointList(_waypoints);
    }


    void Start()
    {
        StartCoroutine(ShootingProjectiles(_targetTransform));
    }

    private void Update()
    {
        _patrolMover.Update(Time.deltaTime);
    }

    private IEnumerator ShootingProjectiles(Transform target)
    {
        yield return null;

        while (enabled)
        {
            _projectileSpawner.Spawn(target);
            yield return new WaitForSeconds(_timeWaitShooting);
        }


    }
}