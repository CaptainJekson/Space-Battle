using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingSlider : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private Product _product;

    private Slider _slider;
    private Text[] _texts;

    private Trader _trader;
    private PlayerShip _playerShip;

    public int Quality { get; private set; }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _texts = GetComponentsInChildren<Text>();
        _trader = FindObjectOfType<Trader>();
    }

    private void Update()
    {
        if (_playerShip == null)
        {
            _playerShip = FindObjectOfType<PlayerShip>();
        }

        if (_product != Product.Repair)
        {
            Quality = (int)Mathf.Round((_slider.value * _maxValue));
        }
        else
        {
            Quality = (int)Mathf.Round(_slider.value * (_playerShip.MaxHealth - _playerShip.Health));
        }

        if (_slider.value < 0)
            _slider.value = 0;

        _texts[1].text = Quality.ToString();

        if (_product == Product.Turred)
            _texts[2].text = (Mathf.Round(_slider.value * _maxValue) * _trader.TurredCost).ToString() + " GC";
        else if (_product == Product.Missile)
            _texts[2].text = (Mathf.Round(_slider.value * _maxValue) * _trader.MissileCost).ToString() + " GC";
        else if (_product == Product.Repair)
            _texts[2].text = (Mathf.Round(_slider.value * (_playerShip.MaxHealth - _playerShip.Health)) * _trader.RepairCost).ToString() + " GC";
    }

    public enum Product
    {
        Repair,
        Turred,
        Missile
    }
}
