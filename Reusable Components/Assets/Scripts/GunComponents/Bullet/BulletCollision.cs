using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GunHandler _gunHandler;
    [SerializeField] private ScoreHandler _scoreHandler;

    private void Start()
    {
        _gunHandler = GetComponentInParent<GunHandler>();
        _scoreHandler = GetComponentInParent<ScoreHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() == null || !collision.GetComponent<Health>().Enemy)
            return;

        Debug.Log(collision.GetComponent<Health>());

        collision.GetComponent<IDamageable>().TakeDamage(_gunHandler.Gun.Damage);
        _scoreHandler.AddScore(10);
        /*
        if (collision.GetComponent<Health>().HealthPoints <= 0)
            _scoreHandler.AddScore(50);*/
        Destroy(this.gameObject);
    }
}
