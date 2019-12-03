using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;

    [SerializeField] private Transform _camera;
    private float _startPositionX, _startPostitionY;

    private void Awake()
    {
        _startPositionX = transform.position.x;
        _startPostitionY = transform.position.y;
    }

    private void Update()
    {
        float distanceX = (_camera.position.x * _parallaxSpeed);
        float distanceY = (_camera.position.y * _parallaxSpeed);

        transform.position = new Vector2(_startPositionX + distanceX, _startPostitionY + distanceY);
    }
}
