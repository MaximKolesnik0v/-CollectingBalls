using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    public Vector3 _center;
    public Vector3 _size;
    public GameObject _meteorite;

    private GameObject[] _findMeteorite;

    readonly int _maxMeteorite = 3;

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Spawn();
        }
    }

    public void Update()
    {
        _findMeteorite = GameObject.FindGameObjectsWithTag("Meteorite");

        if (_findMeteorite.Length < _maxMeteorite)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 position = _center + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), 
                                                          Random.Range(-_size.y / 2, _size.y / 2), 
                                                          Random.Range(-_size.z / 2, _size.z / 2));

        Instantiate(_meteorite, position, Quaternion.identity);
    
    }
}
