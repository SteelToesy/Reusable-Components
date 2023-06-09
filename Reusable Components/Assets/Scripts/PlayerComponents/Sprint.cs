using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    [SerializeField] private float _SprintSpeed;

    private PlayerInput _playerInput;
    private DirectionalMovement _directionalMovement;

    private void Awake()
    {
        _directionalMovement = GetComponent<DirectionalMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
       => Sprinting();

    void Sprinting()
       => _directionalMovement.ChangeSpeed(_playerInput.Sprint ? _SprintSpeed : _directionalMovement.OriginalSpeed); //muy divertido
}
