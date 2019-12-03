using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Unit
{
    [SerializeField] GameObject[] _ores;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Dead()
    {
        int index = Random.Range(0, _ores.Length);

        if (_ores.Length != 0)
            Instantiate(_ores[index], transform.position, Quaternion.identity);

        base.Dead();
    }

}
