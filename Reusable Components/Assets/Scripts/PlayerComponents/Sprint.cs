using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    [SerializeField] private float _SprintSpeed;
    [SerializeField] private PlayerActions _playerActions;

    private DirectionalMovement _directionalMovement;

    public bool Sprinting
        => _playerActions.PlayerMap.Sprint.IsInProgress();

    private void Awake()
    {
        _directionalMovement = GetComponent<DirectionalMovement>();
        _playerActions = new PlayerActions();
    }

    private void OnEnable()
    => _playerActions.PlayerMap.Sprint.Enable();

    private void OnDisable()
        => _playerActions.PlayerMap.Sprint.Disable();

    void Update()
       => ActivateSprint();

    void ActivateSprint()
       => _directionalMovement.ChangeSpeed(Sprinting ? _SprintSpeed : _directionalMovement.OriginalSpeed); //muy divertido
}
