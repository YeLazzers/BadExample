using UnityEngine;

public class PatrolPlaces : MonoBehaviour
{
    [SerializeField] Transform _placesGroup;

    private float _speed;
    private Transform[] _places;
    private int _currentPlaceIndex = 0;

    private void Start()
    {
        _places = new Transform[_placesGroup.childCount];

        for (int childIndex = 0; childIndex < _placesGroup.childCount; childIndex++)
            _places[childIndex] = _placesGroup.GetChild(childIndex).transform;
    }

    private void Update()
    {
        Vector3 nextPosition = _places[_currentPlaceIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);

        if (transform.position == nextPosition) ChangeNextPlace();
    }

    private void ChangeNextPlace()
    {
        _currentPlaceIndex = (_currentPlaceIndex + 1) % _places.Length;
        transform.forward = _places[_currentPlaceIndex].transform.position;
    }
}