using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Unit
{
    private float _speed;
    public float Speed { get => _speed; }

    public bool IsActive { get; set; }
    protected override void Awake()
    {
        _collider = GetComponent<PolygonCollider2D>();
        IsActive = true;

        base.Awake();
    }

    private void FixedUpdate()
    {
        if (IsActive)
            ToControl(KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.A, KeyCode.Q, KeyCode.E, KeyCode.C);
    }

    protected override void Update()
    {
        _speed = _rigidbody.velocity.magnitude * 10.0f;

        base.Update();
    }

    private void ToControl(KeyCode forward, KeyCode backward, KeyCode rotateRight, KeyCode rotateLeft, KeyCode right, KeyCode left, KeyCode stop)
    {
        if (Input.GetKey(forward))
            _rigidbody.AddForce(transform.up * _acceleration * Time.deltaTime);

        if (Input.GetKey(backward))
            _rigidbody.AddForce(-(transform.up) * _acceleration * Time.deltaTime);

        if (Input.GetKey(rotateRight))
            _rigidbody.AddTorque(-(_rotateSpeed) * Time.deltaTime);

        if (Input.GetKey(rotateLeft))
            _rigidbody.AddTorque(_rotateSpeed * Time.deltaTime);

        if (Input.GetKey(right))
            _rigidbody.AddForce(-(transform.right) * _acceleration * Time.deltaTime);

        if (Input.GetKey(left))
            _rigidbody.AddForce(transform.right * _acceleration * Time.deltaTime);

        if (Input.GetKey(stop))
        {
            _rigidbody.angularVelocity = Mathf.Lerp(_rigidbody.angularVelocity, 0, _rotateSpeed * _stopSpeed * 0.01f * Time.deltaTime);
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, _acceleration * _stopSpeed * 0.01f * Time.deltaTime);
        }
    }

    public void FullStop()
    {
        _rigidbody.angularVelocity = Mathf.Lerp(_rigidbody.angularVelocity, 0, _rotateSpeed * 1000.0f * Time.deltaTime);
        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, _acceleration * 1000.0f * Time.deltaTime);
    }

}
