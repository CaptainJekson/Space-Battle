using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    [SerializeField] private LaserProjectile _laserProjectile;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        if(_weaponSelecded.Selected == WeaponSelected.Selection.Laser && _playerShip.IsActive == true)
            ToAttack(KeyCode.Mouse0);

        base.Update();
    }

    private void ToAttack(KeyCode attackKey)
    {
        if (CanAttack && Input.GetKey(attackKey))
        {
            _shootCooldown = _shotingRate;

            LaserProjectile newLaserProjectile = Instantiate(_laserProjectile, _playerShip.transform.position, transform.rotation);

            newLaserProjectile.Parent = _playerShip.gameObject;
            newLaserProjectile.Direction = transform.up;
        }
    }

}
