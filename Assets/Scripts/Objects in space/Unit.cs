using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Unit : MonoBehaviour
{
    [Header("Параметры движения")]
    [SerializeField] protected float _rotateSpeed;
    [SerializeField] protected float _acceleration;
    [SerializeField] protected float _stopSpeed;

    [Header("Прочность")]
    [SerializeField] private int _health;
    [SerializeField] protected bool _mortal;
    [SerializeField] protected GameObject _healthBar;

    protected Rigidbody2D _rigidbody;
    protected PolygonCollider2D _collider;

    public int MaxHealth { get; private set; }
    public int Health { get => _health; set => _health = value; }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        MaxHealth = _health;

        if (_healthBar != null)
            _healthBar.SetActive(false);
    }

    protected virtual void Update()
    {
        if (_health <= 0 && _mortal)
            Dead();

        _rigidbody.angularVelocity = Mathf.Lerp(_rigidbody.angularVelocity, 0, 0.1f * Time.deltaTime);
        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, 0.1f * Time.deltaTime);
    }

    public virtual void ReciveDamage(int damage)
    {
        if (_mortal)
        {
            if (_health > 0)
                _health -= damage;
            else
                Dead();
        }
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }

    protected virtual void OnMouseEnter()
    {
        if (_healthBar != null)
            _healthBar.SetActive(true);
    }

    protected virtual void OnMouseExit()
    {
        if (_healthBar != null)
            _healthBar.SetActive(false);
    }

}
