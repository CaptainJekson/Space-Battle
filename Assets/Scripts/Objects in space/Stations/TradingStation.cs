using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingStation : Station
{
    [SerializeField] private GameObject _panelTrade;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnTriggerStay2D(Collider2D collider)
    {
        PlayerShip playerShip = collider.GetComponent<PlayerShip>();

        base.OnTriggerStay2D(collider);

        if (playerShip)
        {
            if (Input.GetKeyDown(KeyCode.F) && _panelTrade.activeSelf == false)
            {
                _panelTrade.SetActive(true);
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
            _panelTrade.SetActive(false);
    }

    public void OnClickToClose()
    {
        _panelTrade.SetActive(false);
        _playerShip.IsActive = true;
    }
}
