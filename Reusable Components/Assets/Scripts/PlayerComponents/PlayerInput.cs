using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerActions _playerActions;

    void Awake()
        => _playerActions = new PlayerActions();

    private void OnEnable()
    => _playerActions.PlayerMap.Enable();

    private void OnDisable()
        => _playerActions.PlayerMap.Disable();

    public Vector2 Direction
        => _playerActions.PlayerMap.Movement.ReadValue<Vector2>();

    public float Sprint
        => _playerActions.PlayerMap.Sprint.ReadValue<float>();

    public float Fire 
        => _playerActions.PlayerMap.Fire.ReadValue<float>();
}
