using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerActions _playerActions;

    private bool _fire = false;
    public bool Fire
    {
        get => _fire;
    }
        

    void Awake()
        => _playerActions = new PlayerActions();

    private void OnEnable()
    {
        _playerActions.PlayerMap.Enable();
        //_playerActions.PlayerMap.Fire.performed += Fire_performed;
    }



    private void OnDisable()
    {
        _playerActions.PlayerMap.Disable();
        //_playerActions.PlayerMap.Fire.performed -= Fire_performed;
    }

    public Vector2 Direction
        => _playerActions.PlayerMap.Movement.ReadValue<Vector2>();

    public bool Sprint
        => _playerActions.PlayerMap.Sprint.IsInProgress();

    //public void Fire_performed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Nothing");
    //    //if (obj.started)
    //    //    _fire = true;
    //    //if (obj.performed)
    //    //    _fire = false;
    //    //if (obj.canceled)
    //    //    _fire = false;
    //}
}
