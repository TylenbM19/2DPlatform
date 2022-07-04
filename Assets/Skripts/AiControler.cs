using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : Controler
{
    [SerializeField] private Transform[] _points;

    private int _currentPointIndex = 0;

    private void FixedUpdate()
    {
        if (IsReachPoint(_points[_currentPointIndex]))
        {
            SelectNextPointers();
        }
        
        Vector2 direction = DirectionToPoint(_points[_currentPointIndex]);
        InvokeEventMove(direction);
    }

    private bool IsReachPoint(Transform point)
    {
        const float TrashHold = 1f;
        float distanseToPoint = Mathf.Abs(gameObject.transform.position.x - point.position.x);
        return distanseToPoint < TrashHold;
    }

    private Vector2 DirectionToPoint(Transform point)
    {
        float xDirection = (point.position - gameObject.transform.position).x;
        return new Vector2(xDirection, 0).normalized;
    }

    private void SelectNextPointers()
    {
        _currentPointIndex++;

        if (_currentPointIndex >= _points.Length)
        {
            _currentPointIndex = 0;
        }
    }
}
