using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerInput _playerInput;
    private GunHandler _gunHolder;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _gunHolder = GetComponent<GunHandler>();
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (_playerInput.Fire > 0) _gunHolder.Shoot();
        Debug.Log(_gunHolder);
    }
}
