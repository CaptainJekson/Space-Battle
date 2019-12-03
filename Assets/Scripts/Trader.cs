using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [Header("Цены на аммуницию")]
    [SerializeField] private float _repairCost;
    [SerializeField] private float _turredCost;
    [SerializeField] private float _missileCost;

    [Header("Слайдеры")]
    [SerializeField] private TradingSlider[] _sliders;
    private Player _player;
    private PlayerShip _playerShip;

    public float Total { get; private set; }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {

        float repairWork = _sliders[0].Quality * _repairCost;
        float turredShells = _sliders[1].Quality * _turredCost;
        float missileShells = _sliders[2].Quality * _missileCost;

        Total = turredShells + missileShells + repairWork;
    }

    public float RepairCost { get => _repairCost;}
    public float TurredCost { get => _turredCost;}
    public float MissileCost { get => _missileCost;}

    public void MakeTransactions()
    {
        _playerShip = FindObjectOfType<PlayerShip>();


        if(Total <= _player.GalacticCoins)
        {
            _player.GalacticCoins -= Total;
            _playerShip.Health += _sliders[0].Quality;
            _player.QuantityTurret += _sliders[1].Quality;
            _player.QuantityMissile += _sliders[2].Quality;
        }

    }
}
