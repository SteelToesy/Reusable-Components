using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private WaveManager _waveManager;

    [SerializeField] private GunHandler _gunHandler;
    [SerializeField] private ScoreHandler _scoreHandler;
    
    [SerializeField] private TMP_Text _mode;
    [SerializeField] private TMP_Text _wave;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _ammo;
    [SerializeField] private TMP_Text _weapon;

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
        _score.text = _scoreHandler.Score.ToString();
        _wave.text = _waveManager.Wave.ToString();
        if (_gunHandler.Gun != null)
        {
            _mode.text= _gunHandler.Gun.CurrentMode.Name.ToString();
            _weapon.text = _gunHandler.Gun.Name;
            _ammo.text = _gunHandler.Gun.Ammo.ToString() + "/" + _gunHandler.Gun.StashAmmo.ToString();
        }
    }
}
