using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _despawnTime;
    private Rigidbody2D _rb;

    private void Awake()
        => _rb = GetComponent<Rigidbody2D>();
    void Start()
        => _despawnTime += Time.time;

    private void Update()
    {
        _rb.velocity = transform.right * _bulletSpeed; //transform.right = direction
        if (Time.time > _despawnTime) Destroy(this.gameObject);
    }
}
