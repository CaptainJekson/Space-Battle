using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private PlayerShip _playerShip;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        if (_playerShip == null)
        {
            _playerShip = FindObjectOfType<PlayerShip>();
        }

        _text.text =  _playerShip.Speed.ToString("0#.##");
    }
}
