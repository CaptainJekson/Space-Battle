using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] private TypeOre _typeOre;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PlayerShip")
        {
            switch (_typeOre)
            {
                case TypeOre.Iron:
                    _player.Iron += Random.Range(min, max);
                    break;
                case TypeOre.Palladium:
                    _player.Palladium += Random.Range(min, max);
                    break;
                case TypeOre.Iridium:
                    _player.Iridium += Random.Range(min, max);
                    break;
                case TypeOre.Tritium:
                    _player.Tritium += Random.Range(min, max);
                    break;
            }
        }

        Destroy(gameObject);
    }

    private enum TypeOre
    {
        Iron,
        Palladium,
        Iridium,
        Tritium
    }
}
