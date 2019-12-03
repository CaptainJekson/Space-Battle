using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int _maxHealth;
    private PlayerShip _playerShip;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if(_playerShip == null)
        {
            _playerShip = FindObjectOfType<PlayerShip>();
            _maxHealth = _playerShip.Health;
        }

        _image.fillAmount = (float)_playerShip.Health / _maxHealth;
    }
}
