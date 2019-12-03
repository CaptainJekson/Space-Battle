using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class WarpStation : Station
{
    [SerializeField] private GameObject _panelGalaxyMap;

    protected override void OnTriggerStay2D(Collider2D collider)
    {
        PlayerShip playerShip = collider.GetComponent<PlayerShip>();

        base.OnTriggerStay2D(collider);

        if (playerShip)
        {
            if (Input.GetKeyDown(KeyCode.F) && _panelGalaxyMap.activeSelf == false)
            {
                _panelGalaxyMap.SetActive(true);
                playerShip.FullStop();
                playerShip.IsActive = false;
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        PlayerShip playerShip = collider.GetComponent<PlayerShip>();

        base.OnTriggerExit2D(collider);

        if (playerShip)
            _panelGalaxyMap.SetActive(false);
    }

    public void OnClickToClose()
    {
        _panelGalaxyMap.SetActive(false);
        _playerShip.IsActive = true;
    }
}
