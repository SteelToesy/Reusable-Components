using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float _bulletSpeed;
    private Rigidbody2D _rb;

    private void Awake()
        => _rb = GetComponent<Rigidbody2D>();
    void Start()
        => _rb.velocity = transform.right * _bulletSpeed; //transform.right = direction
}
