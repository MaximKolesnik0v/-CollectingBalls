using System;
using UnityEngine;

public class LevelObjectView : MonoBehaviour
{
    public Transform _transform;
    public Collider _collider;
    public Rigidbody _rigidbody;

    public Action<LevelObjectView> OnLevelObjectContact { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        LevelObjectView levelObject = other.gameObject.GetComponent<LevelObjectView>();
        OnLevelObjectContact?.Invoke(levelObject);
    }
}
