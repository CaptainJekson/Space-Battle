using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCost : MonoBehaviour
{
    private Trader _trader;
    private Text _text;

    private void Awake()
    {
        _trader = FindObjectOfType<Trader>();
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = "Total: " + _trader.Total.ToString() + " GC";
    }

}
