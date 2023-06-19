using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GunHandler _gunHandler;
    [SerializeField] private ScoreHandler _scoreHandler;

    [SerializeField] private TMP_Text _Score;
    [SerializeField] private TMP_Text _Ammo;
    [SerializeField] private TMP_Text _Weapon;

    private void Awake()
    {
        _gunHandler = _player.GetComponent<GunHandler>();
        _scoreHandler = _player.GetComponent<ScoreHandler>();
    }

    void Update()
    {
        SetUIValues();
    }

    void SetUIValues()
    {
        _Score.text = _scoreHandler.Score.ToString();
        if (_gunHandler.Gun != null)
        {
            _Weapon.text = _gunHandler.Gun.Name;
            _Ammo.text = _gunHandler.Gun.Ammo.ToString() + "/" + _gunHandler.Gun.StashAmmo.ToString();
        }

        //_Weapon.text = _gunHandler.Gun.Name;
        //_Ammo.text = _gunHandler.Gun.Ammo.ToString() + "/" + _gunHandler.Gun.StashAmmo.ToString();
    }
}
