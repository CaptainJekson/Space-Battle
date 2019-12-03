using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _timeLife;
    [SerializeField] protected int _damage;

    protected Vector3 _direction;
    protected GameObject _parent;

    public GameObject Parent { set => _parent = value; }
    public Vector3 Direction { set => _direction = value; get => _direction; }

    protected virtual void Start()
    {
        Destroy(gameObject, _timeLife);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit.gameObject != _parent)
        {
            unit.ReciveDamage(_damage);
            Destroy(gameObject);
        }       
    }
}