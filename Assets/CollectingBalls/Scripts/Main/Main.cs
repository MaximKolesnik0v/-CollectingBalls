using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private LevelObjectView _playerView;
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private Transform _spawnPoint;

    private PlayerController _playerController;


    void Awake()
    {
        _playerController = new PlayerController(_playerView, _cameraView, _spawnPoint);

        Cursor.visible = false;
    }

    void Start()
    {
        _playerController.Start();
    }

    void FixedUpdate()
    {
        if(_playerView != null) _playerController.FixedUpdate();
    }
}
