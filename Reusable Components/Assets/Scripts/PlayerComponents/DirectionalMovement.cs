using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionalMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerActions _playerActions;
    private float _originalSpeed;

    private Rigidbody2D _rb;
    private Vector2 _moveInput;

    public float OriginalSpeed { get { return _originalSpeed; } }

    public Vector2 Direction
        => _playerActions.PlayerMap.Movement.ReadValue<Vector2>();

    private void Awake()
    {
        _originalSpeed = _speed;
        _rb = GetComponent<Rigidbody2D>();
        _playerActions = new PlayerActions();
    }

    private void OnEnable()
        => _playerActions.PlayerMap.Movement.Enable();

    private void OnDisable()
        => _playerActions.PlayerMap.Movement.Disable();

    private void Update()
        => _moveInput = Direction;

    private void FixedUpdate()
        => _rb.velocity = _moveInput.normalized * _speed;

    public void ChangeSpeed(float pNewSpeed)
        => _speed = pNewSpeed;
}
