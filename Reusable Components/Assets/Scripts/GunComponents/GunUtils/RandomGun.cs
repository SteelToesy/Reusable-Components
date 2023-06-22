using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGun : MonoBehaviour
{
    [SerializeField] private float _activationCost;
    [SerializeField] private List<GameObject> _guns = new();
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] protected PlayerActions _playerActions;

    void OnEnable()
      => _playerActions.PlayerMap.Interact.Enable();

    void OnDisable()
        => _playerActions.PlayerMap.Interact.Disable();

    private void Awake()
    {
        _playerActions = new PlayerActions();
    }

    public void SpawnRandomGun()
    {
        Instantiate(_guns[Random.Range(0, _guns.Count)]);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        _scoreHandler = collision.GetComponent<ScoreHandler>();

        if (_playerActions.PlayerMap.Interact.IsPressed() && _scoreHandler.Score >= _activationCost)
            SpawnRandomGun();
    }
}
