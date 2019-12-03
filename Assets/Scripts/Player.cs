using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("На время для отладки")]
    [SerializeField] private Vector3 startPos;

    [Header("Боезапас")]
    [SerializeField] private int _quantityTurret;
    [SerializeField] private int _quantityMissile;

    [Header("Русурсы")]
    [SerializeField] private int _iron;
    [SerializeField] private int _palladium;
    [SerializeField] private int _iridium;
    [SerializeField] private int _tritium;

    [SerializeField] private float _galacticCoins;

    private PlayerShip _playerShip;

    public int QuantityTurret
    {
        get => _quantityTurret;
        set
        {
            if (value >= 0)
                _quantityTurret = value;
        }
    }

    public int QuantityMissile
    {
        get => _quantityMissile;
        set
        {
            if (value >= 0)
                _quantityMissile = value;
        }
    }

    public int Iron
    {
        get => _iron;
        set
        {
            if (value >= 0)
                _iron = value;
        }
    }

    public int Palladium
    {
        get => _palladium;
        set
        {
            if (value >= 0)
                _palladium = value;
        }
    }

    public int Iridium
    {
        get => _iridium;
        set
        {
            if (value >= 0)
                _iridium = value;
        }
    }

    public int Tritium
    {
        get => _tritium;
        set
        {
            if (value >= 0)
                _tritium = value;
        }
    }

    public float GalacticCoins
    {
        get => _galacticCoins;
        set
        {
            if (value >= 0)
                _galacticCoins = value;
        }
    }

    private void Awake()
    {
        _playerShip = Resources.Load<PlayerShip>(PlayerPrefs.GetString("SelectedShip"));
        Instantiate(_playerShip, startPos, transform.rotation);
    }
}
