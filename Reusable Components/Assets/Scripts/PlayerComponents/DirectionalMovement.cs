using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionalMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _originalSpeed;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;

    public float OriginalSpeed { get { return _originalSpeed; } }

    private void Awake()
    {
        _originalSpeed = _speed;
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
        => _moveInput = _playerInput.Direction;

    private void FixedUpdate()
        => _rb.velocity = _moveInput.normalized * _speed;

    public void ChangeSpeed(float pNewSpeed)
        => _speed = pNewSpeed;
}
