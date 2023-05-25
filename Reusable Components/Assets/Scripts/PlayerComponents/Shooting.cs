using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerInput _playerInput;
    private GunHolder _gunHolder;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _gunHolder = GetComponentInChildren<GunHolder>();
    }

    private void Update()
    {
        if (_playerInput.Fire > 0) _gunHolder.Shoot();
    }
}
