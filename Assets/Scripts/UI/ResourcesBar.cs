using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesBar : MonoBehaviour
{
    private Player _player;
    private Text[] _texts;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _texts = GetComponentsInChildren<Text>();
    }

    private void Update()
    {
        _texts[0].text = "iron: " + _player.Iron.ToString();
        _texts[1].text = "palladium: " + _player.Palladium.ToString();
        _texts[2].text = "iridium: " + _player.Iridium.ToString();
        _texts[3].text = "tritium: " + _player.Tritium.ToString();
        _texts[4].text = "Galactic Coins: " + _player.GalacticCoins.ToString("#.##");
    }
}
