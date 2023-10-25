using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private List<GameObject> _zombieTypes = new();
    [SerializeField] private List<GameObject> _currentZombies = new();

    [SerializeField] private bool _allowSpawn = true;
    [SerializeField] private int _maxZombies;
    [SerializeField] private int _currentWave;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private int _spawnDelay;
    [SerializeField] private int _zombiesSpawned;
    [SerializeField] private int _nextRoundDelay;

    [SerializeField] private int _waveIncreaseZombies;

    public int Wave
    {
        get => _currentWave;
    }

    private void Update()
    {
        CheckRound();
        CheckZombies();
        RunRound();
    }

    IEnumerator Spawner()
    {
        if (_maxZombies > _currentZombies.Count && _allowSpawn)
        {
            _allowSpawn = false;
            SpawnZombie();
            yield return new WaitForSeconds(_spawnDelay);
            _allowSpawn = true;
        }
    }

    void RunRound()
    {
        if (_spawnAmount > _zombiesSpawned)
            StartCoroutine(Spawner());
    }

    void SpawnZombie()
    {
        int zombietype = Random.Range(0, _zombieTypes.Count);
        int spawnpoint = Random.Range(0, _spawnPoints.Count);
        GameObject zombie = Instantiate(_zombieTypes[zombietype], _spawnPoints[spawnpoint]);
        zombie.GetComponent<ZombieFollow>().SetTarget(_target);
        Debug.Log(_target);
        _currentZombies.Add(zombie);
        _zombiesSpawned++;
    }

    void CheckRound()
    {
        if (!EndOfRound())
            return;

        StartCoroutine(RoundDelay());
        _currentWave++;
        _maxZombies += _waveIncreaseZombies;
        _spawnAmount += _waveIncreaseZombies;
    }

    void CheckZombies()
    {
        foreach (GameObject zombie in _currentZombies)
            if (zombie.GetComponent<ZombieHealth>().Health <= 0) //getComponent in Update??
            {
                _currentZombies.Remove(zombie);
                Destroy(zombie);
            }
    }

    bool EndOfRound()
    {
        if (_currentZombies.Count <= 0 && _spawnAmount == _zombiesSpawned)
        {
            _zombiesSpawned = 0;
            return true;
        }
        else return false;
    }

    IEnumerator RoundDelay()
    {
        _allowSpawn = false;
        yield return new WaitForSeconds(_nextRoundDelay);
        _allowSpawn = true;
    }
}
