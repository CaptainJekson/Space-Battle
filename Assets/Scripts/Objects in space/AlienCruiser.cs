using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCruiser : Unit
{
    [SerializeField] private Transform[] _points;
    private int _indexPoint = 0;

    private void FixedUpdate()
    {
        if (_points != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_indexPoint].position, _acceleration * Time.deltaTime);

            float angle = Vector2.Angle(Vector2.right, _points[_indexPoint].position - transform.position);

            Quaternion q1 = Quaternion.Euler(0f, 0f, transform.position.y < _points[_indexPoint].position.y ? angle - 90 : -angle - 90);

            transform.rotation = q1;

            if (transform.position == _points[_indexPoint].position)
            {
                if (_indexPoint != _points.Length - 1)
                    _indexPoint++;
                else
                    _indexPoint = 0;
            }
        }
    }
}
