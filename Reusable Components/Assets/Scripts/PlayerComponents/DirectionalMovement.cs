using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionalMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerActions _playerActions;
    private Rigidbody _rb;
    private Vector2 _moveInput;

    private void Awake()
    {
        _playerActions = new PlayerActions();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
        => _moveInput = _playerActions.PlayerMap.Movement.ReadValue<Vector2>();

    private void FixedUpdate()
        => _rb.velocity = _moveInput.normalized * _speed;

    private void OnEnable()
        => _playerActions.PlayerMap.Enable();

    private void OnDisable()
        => _playerActions.PlayerMap.Disable();
}
