using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, IPickupable
{
    [SerializeField] private GunBase _gun;
    [SerializeField] private Sprite _gunTexture;

    [SerializeField] private GunHandler _gunHandler;

    [SerializeField] protected PlayerActions _playerActions;

    void OnEnable()
        => _playerActions.PlayerMap.Interact.Enable();

    void OnDisable()
        => _playerActions.PlayerMap.Interact.Disable();

    void Awake()
    {
        _gun = GetComponent<GunBase>();
        _playerActions = new PlayerActions();
    }

    void OnTriggerEnter2D(Collider2D collision)
        => _gunHandler = collision.GetComponent<GunHandler>();

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!_gunHandler || collision.GetComponent(_gun.GetType())) // if the player already has the gun, don't let him
            return;

        if (_playerActions.PlayerMap.Interact.IsPressed())
        {
            _gunHandler.AddGun(_gun, _gunTexture);
            Destroy(this.gameObject);
        }
    }
}
