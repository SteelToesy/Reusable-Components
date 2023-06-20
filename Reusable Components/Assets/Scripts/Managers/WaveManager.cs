using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private List<GameObject> _zombieTypes = new();
    [SerializeField] private List<GameObject> _currentZombies = new();

    [SerializeField] private bool _allowSpawn = true;
    [SerializeField] private int _maxZombies;
    [SerializeField] private int _currentWave;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private int _spawnDelay;
    [SerializeField] private int _zombiesSpawned;

    private void Update()
    {
        CheckZombies();
        RunRound();
    }

    IEnumerator Spawner()
    {
        if (_maxZombies > _currentZombies.Count && _allowSpawn)
        {
            _allowSpawn = false;
            SpawnZombie();
            _zombiesSpawned++;
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
        int spawnpoint = Random.Range(0, _spawnPoints.Count);
        GameObject zombie = Instantiate(_zombieTypes[0], _spawnPoints[spawnpoint]); //hardcoded
        _currentZombies.Add(zombie);
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
}
