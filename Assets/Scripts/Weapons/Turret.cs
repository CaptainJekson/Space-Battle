using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Weapon
{
    [SerializeField] private float _speedRotate;
    [SerializeField] private LaserProjectile _laserProjectile;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        if (_weaponSelecded.Selected == WeaponSelected.Selection.Turred && _playerShip.IsActive == true)
        {
            ToRotateTurret();
            ToAttack(KeyCode.Mouse0);
        }

        base.Update();
    }

    private void ToRotateTurret()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);

        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle - 90 : -angle - 90);
    }

    private void ToAttack(KeyCode attackKey)
    {
        if (CanAttack && Input.GetKey(attackKey) && _player.QuantityTurret > 0)
        {
            _shootCooldown = _shotingRate;

            LaserProjectile newLaserProjectile = Instantiate(_laserProjectile, transform.position, transform.rotation);

            newLaserProjectile.Parent = _playerShip.gameObject;
            newLaserProjectile.Direction = transform.up;

            _player.QuantityTurret--;
        }
    }
}
