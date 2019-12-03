using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPicture : MonoBehaviour
{
    private Image _imageShipSelected;
    [SerializeField] ToggleGroup _allShipToggleGroup;

    private void Awake()
    {
        _imageShipSelected = GetComponent<Image>();
    }

    private void Update()
    {
        IEnumerable<Toggle> togglesActive = _allShipToggleGroup.ActiveToggles();

        foreach (var toggle in togglesActive)
        {
            _imageShipSelected.sprite = toggle.image.sprite;
        }
    }

}
