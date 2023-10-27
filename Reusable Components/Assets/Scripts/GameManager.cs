using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;

    [SerializeField] private Health _playerHealth;

    private void Update()
    {
        CheckConditions();
    }

    void CheckConditions()
    {
        if (_playerHealth.HealthPoints <= 0)
        {
            SceneManager.LoadScene(3);
            Debug.Log("dead");
        }

        if (_waveManager.Wave >= 11)
        {
            SceneManager.LoadScene(2);
            Debug.Log("W");
        }
    }
}
