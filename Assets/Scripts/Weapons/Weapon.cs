using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _shotingRate;

    protected float _shootCooldown;
    protected private Player _player;
    protected WeaponSelected _weaponSelecded;
    protected PlayerShip _playerShip;

    public bool CanAttack => _shootCooldown <= 0.0f;

    protected virtual void Awake()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
        _player = FindObjectOfType<Player>();
        _weaponSelecded = FindObjectOfType<WeaponSelected>();
        _shootCooldown = 0.0f;
    }

    protected virtual void Update()
    {
        if (_shootCooldown > 0)
            _shootCooldown -= Time.deltaTime;
    }

}
