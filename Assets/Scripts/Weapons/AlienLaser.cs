using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLaser : Weapon
{
    [SerializeField] private LaserProjectile _laserProjectile;
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<PlayerShip>().transform;
    }

    protected override void Awake()
    {
        _shootCooldown = 0.0f;
    }

    protected override void Update()
    {
        ToAttack();

        base.Update();
    }

    private void ToAttack()
    {
        if(_target != null)
        {
            if (CanAttack && Vector3.Distance(_target.position, transform.position) < 8.0f)
            {
                _shootCooldown = _shotingRate;

                LaserProjectile newLaserProjectile = Instantiate(_laserProjectile, transform.position, transform.rotation);

                newLaserProjectile.Parent = gameObject;
                newLaserProjectile.Direction = transform.up;
            }
        }
    }
}
