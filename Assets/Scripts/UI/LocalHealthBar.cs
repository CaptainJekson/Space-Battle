using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalHealthBar : MonoBehaviour
{
    private Unit _unit;
    private int _healthMax;
    private Quaternion _rotation;

    private void Awake()
    {
        _unit = GetComponentInParent<Unit>();
        _healthMax = _unit.Health;
        _rotation = transform.rotation;
    }

    private void Update()
    {
        float currentHealth = (float)_unit.Health / _healthMax;

        transform.localScale = new Vector3(currentHealth, 1.0f, 1.0f);
    }

    private void LateUpdate()
    {
        transform.rotation = _rotation;
    }
}

