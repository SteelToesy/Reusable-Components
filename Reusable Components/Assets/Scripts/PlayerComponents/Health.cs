using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthPoints => _health;
    public void TakeDamage(float pDamage)
    {
        _health -= pDamage;
    }
}
