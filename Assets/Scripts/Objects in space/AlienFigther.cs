using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFigther : Unit
{
    private Transform _target;
    private float _distance;

    private void Start()
    {
        _target = FindObjectOfType<PlayerShip>().transform;
        _acceleration *= 0.01f;
    }

    protected override void Update()
    {
        if (_target != null)
            _distance = Vector3.Distance(_target.position, transform.position);

        base.Update();
    }

    private void FixedUpdate()
    {
        if(_target != null)
        {
            if (_distance > 5 && _distance < 20)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position, _acceleration * Time.deltaTime);
            }

            float angle = Vector2.Angle(Vector2.right, _target.position - transform.position);

            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < _target.position.y ? angle - 90 : -angle - 90);
        }

    }
}
