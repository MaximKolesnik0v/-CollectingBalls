using UnityEngine;

public class PlayerController
{
    private LevelObjectView _view;
    private CameraView _camera;
    private Transform _spawn;

    private float _speed = 200f;
    private float _jumpForce = 300f;


    public PlayerController(LevelObjectView Player, CameraView Camera, Transform SpawnPoint)
    {
        _view = Player;
        _camera = Camera;
        _spawn = SpawnPoint;
    }


    public void Start()
    {
        Physics.defaultMaxDepenetrationVelocity = 50f;
        SetSpawnPosition();
    }

    public void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
        {
            _view._rigidbody.AddForce(_camera.transform.forward * _speed * Time.deltaTime);
        }

        if (moveVertical < 0)
        {
            _view._rigidbody.AddForce(-_camera.transform.forward * _speed * Time.deltaTime);
        }

        if (moveHorizontal > 0)
        {
            _view._rigidbody.AddForce(_camera.transform.right * _speed * Time.deltaTime);
        }

        if (moveHorizontal < 0)
        {
            _view._rigidbody.AddForce(-_camera.transform.right * _speed * Time.deltaTime);
        }
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (Mathf.Abs(_view._rigidbody.velocity.y) <= 0.0003f)
            {
                _view._rigidbody.AddForce(Vector3.up * _jumpForce);
            }
        }
    }

    private void SetSpawnPosition()
    {
        _view.transform.position = _spawn.position;
    }
}
