using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] public float _speed;
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<PlayerShip>().transform;
    }

    private void Update()
    {
        if(_target != null)
        {
            Vector3 position = _target.position;
            position.z = -10f;

            transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
        }
    }
}
