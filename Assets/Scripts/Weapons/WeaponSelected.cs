using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelected : MonoBehaviour
{
    protected Selection _selected;

    public Selection Selected { get => _selected; }

    private  void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))
            _selected = Selection.Laser;

        else if (Input.GetKey(KeyCode.Alpha2))
            _selected = Selection.Turred;

        else if (Input.GetKey(KeyCode.Alpha3))
            _selected = Selection.Missile;
    }

    public enum Selection   
    {
        Laser,
        Turred,
        Missile
    }
}
