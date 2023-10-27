using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHealth : MonoBehaviour
{
    [SerializeField] private Health  _health;
    [SerializeField] private List<Transform> _healthObjects = new List<Transform>();
    void Start()
    {
        for (int i = 0; i<transform.childCount; i++)
            _healthObjects.Add(transform.GetChild(i));
    }

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        for (int i = 0, o = 0; i<_healthObjects.Count; i++, o=5)
        {
            if (_health.HealthPoints <= (o * i))
                _healthObjects[i].position = new(10000, 10000, 10000); //to the shadow realm, ultra mega scuffed
        }
    }
}
