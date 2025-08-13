using System.Collections.Generic;
using UnityEngine;

public class PatrolMover
{
    private Transform _characterTransform;
    private float _movementSpeed;
    private List<Transform> _waypoints;
    private int _currentWaypointIndex = 0;
    private Transform _nextWaypoint => _waypoints.Count > 0 ? _waypoints[(_currentWaypointIndex + 1) % _waypoints.Count] : null;

    public PatrolMover(Transform characterTransform, float speed)
    {
        _characterTransform = characterTransform;
        _movementSpeed = speed;
    }

    public void SetWaypointList(List<Transform> waypoints)
    {
        _waypoints = waypoints;

        if (waypoints.Count > 0)
        {
            _characterTransform.position = waypoints[_currentWaypointIndex].position;
        }
    }

    public void Update(float deltaTime)
    {
        if (_nextWaypoint != null)
        {
            _characterTransform.LookAt(_nextWaypoint.position);
            _characterTransform.position = Vector3.MoveTowards(_characterTransform.position, _nextWaypoint.position, _movementSpeed * Time.deltaTime);

            if (_characterTransform.position == _nextWaypoint.position)
            {
                _currentWaypointIndex++;
            }
        }
    }
}
