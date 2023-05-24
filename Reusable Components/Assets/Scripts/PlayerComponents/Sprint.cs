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

    // Update is called once per frame
    void Update()
       => Sprinting();

    void Sprinting()
       => _directionalMovement.ChangeSpeed(_playerInput.Sprint > 0 ? _SprintSpeed : _directionalMovement.OriginalSpeed);
}
