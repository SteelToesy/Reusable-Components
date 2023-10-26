using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private float _attackDelayTime;
    [SerializeField] private bool _canAttack = true;
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() && _canAttack)
        {
            _canAttack = false;
            collision.GetComponent<Health>().TakeDamage(5);
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(_attackDelayTime);
        _canAttack = true;
    }
}
