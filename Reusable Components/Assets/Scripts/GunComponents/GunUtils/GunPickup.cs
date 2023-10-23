using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, IPickupable
{
    [SerializeField] private GameObject _gun;
    [SerializeField] private GunHandler _gunHandler;

    [SerializeField] protected PlayerActions _playerActions;

    void OnEnable()
        => _playerActions.PlayerMap.Interact.Enable();

    void OnDisable()
        => _playerActions.PlayerMap.Interact.Disable();

    void Awake()
    {
        _gun = this.gameObject;
        _playerActions = new PlayerActions();
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        _gunHandler = collision.GetComponent<GunHandler>();
        if (!_gunHandler)
            return;

        if (_playerActions.PlayerMap.Interact.IsPressed())
        {
            _gunHandler.AddGun(_gun);
            Destroy(gameObject);
            Debug.Log("Reach");
        }
    }
}
