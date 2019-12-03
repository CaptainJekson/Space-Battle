using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : Unit
{
    [SerializeField] protected GameObject _panelDocking;

    protected PlayerShip _playerShip;

    protected virtual void Start()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    protected virtual void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }

    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        PlayerShip playerShip = collider.GetComponent<PlayerShip>();

        if (playerShip)
        {
            _panelDocking.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        PlayerShip playerShip = collider.GetComponent<PlayerShip>();

        if (playerShip)
            _panelDocking.SetActive(false);
    }
}
