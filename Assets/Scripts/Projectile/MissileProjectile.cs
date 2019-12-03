using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProjectile : Projectile
{
    Vector3 _mousePosition;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Vector2.Angle(Vector2.right, _mousePosition - transform.position);

        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < _mousePosition.y ? angle - 90 : -angle - 90);

        if (Vector3.Distance(_mousePosition, transform.position) < 0.2f)
            Destroy(gameObject);
    }

    protected void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mousePosition + _direction, _speed * Time.deltaTime);
    }
}
