using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Weapon
{
    [SerializeField] private MissileProjectile _missileProjectile;

    protected override void Awake()
    {        
        base.Awake();
    }

    protected override void Update()
    {
        if (_weaponSelecded.Selected == WeaponSelected.Selection.Missile && _playerShip.IsActive == true)
            ToAttack(KeyCode.Mouse0);

        base.Update();
    }

    private void ToAttack(KeyCode attackKey)
    {
        if (CanAttack && Input.GetKey(attackKey) && _player.QuantityMissile > 0)
        {
            _shootCooldown = _shotingRate;

            MissileProjectile newMissileProjectile = Instantiate(_missileProjectile, _playerShip.transform.position, transform.rotation);

            newMissileProjectile.Parent = _playerShip.gameObject;
            newMissileProjectile.Direction = transform.up;

            _player.QuantityMissile--;
        }
    }

}