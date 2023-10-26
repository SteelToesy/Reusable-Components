using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    public float Health
    {
        get => _health;
    }
    
    void Awake()
        => _health = _maxHealth;

    public void TakeDamage(float pDamage)
    {
        _health -= pDamage;
        if (_health <= 0 )
           Destroy(this.gameObject);
    }
}
