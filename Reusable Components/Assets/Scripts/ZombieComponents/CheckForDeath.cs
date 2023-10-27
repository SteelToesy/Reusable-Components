using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDeath : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Update()
    {
        if (_health.HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
