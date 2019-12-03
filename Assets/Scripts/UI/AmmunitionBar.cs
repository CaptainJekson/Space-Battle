using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionBar : MonoBehaviour
{
    private Text _text;
    private Player _player;
    private WeaponSelected _weaponSelected;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _player = FindObjectOfType<Player>();
        _weaponSelected = FindObjectOfType<WeaponSelected>();
    }

    private void Update()
    {
        if (_weaponSelected.Selected == WeaponSelected.Selection.Laser)
            _text.text = "Laser: ∞";

        if (_weaponSelected.Selected == WeaponSelected.Selection.Turred)
            _text.text = $"Turred: {_player.QuantityTurret.ToString()}";

        else if (_weaponSelected.Selected == WeaponSelected.Selection.Missile)
            _text.text = $"Missile: {_player.QuantityMissile.ToString()}";
    }
}
