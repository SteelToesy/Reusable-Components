using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    [SerializeField] private bool _enemy;

    public bool Enemy => _enemy;

    public float HealthPoints => _health;
    public void TakeDamage(float pDamage)
    {
        _health -= pDamage;
    }
}
