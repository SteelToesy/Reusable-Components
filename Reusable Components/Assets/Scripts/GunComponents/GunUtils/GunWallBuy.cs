using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunWallBuy : MonoBehaviour, IPickupable
{
    [SerializeField] private GunBase _gun;
    [SerializeField] private Sprite _gunTexture;
    [SerializeField] private int _gunCost;

    [SerializeField] private GunHandler _gunHandler;
    [SerializeField] private ScoreHandler _scoreHandler;

    [SerializeField] protected PlayerActions _playerActions;

    void OnEnable()
        => _playerActions.PlayerMap.Interact.Enable();

    void OnDisable()
        => _playerActions.PlayerMap.Interact.Disable();

    void Awake()
    {
        _gun = GetComponent<GunBase>();
        _gunCost = _gun.GunCost;
        _playerActions = new PlayerActions();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _gunHandler = collision.GetComponent<GunHandler>();
        _scoreHandler = collision.GetComponent<ScoreHandler>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!_gunHandler || !_scoreHandler || _scoreHandler.Score < _gunCost || !_playerActions.PlayerMap.Interact.IsPressed())
            return;

        if (collision.GetComponent(_gun.GetType()))
            _gunHandler.Gun.RefillAmmo();
        else 
            _gunHandler.AddGun(_gun, _gunTexture);

        _scoreHandler.RemoveScore(500);
    }
}

