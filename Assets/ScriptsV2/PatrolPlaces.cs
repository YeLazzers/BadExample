using UnityEngine;

public class PatrolPlaces : MonoBehaviour
{
    [SerializeField] private Transform _placesGroup;

    private float _speed;
    private Transform[] _places;
    private int _currentPlaceIndex = -1;

    private void Start()
    {
        _places = new Transform[_placesGroup.childCount];

        for (int childIndex = 0; childIndex < _places.Length; childIndex++)
            _places[childIndex] = _placesGroup.GetChild(childIndex);

        SwitchNextPlace();
    }

    private void Update()
    {
        Vector3 nextPosition = _places[_currentPlaceIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);

        if (transform.position == nextPosition)
            SwitchNextPlace();
    }

    private void SwitchNextPlace()
    {
        int nextIndex = ++_currentPlaceIndex % _places.Length;
        transform.forward = _places[nextIndex].transform.position - transform.position;
    }
}