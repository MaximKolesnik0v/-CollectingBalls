using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private Transform _spawmPosition;

    private int _currentPoint;

    private void Start()
    {
        transform.position = _spawmPosition.position;
    }

    private void Update()
    {
        if (_currentPoint + 1 >= _points.Length)
        {
            _currentPoint = 0;
        }

        float _currentDistance = Vector3.Distance(transform.position, _points[_currentPoint].position);

        if (_currentDistance <= _distance)
        {
            _currentPoint++;
        }

        transform.LookAt(_points[_currentPoint].position);

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);

    }
}
