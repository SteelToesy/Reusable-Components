using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _body;

    private float _horizontalAxis;
    private float _verticalAxis;
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontalAxis = Input.GetAxisRaw("Horizontal");
        _verticalAxis = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(_horizontalAxis, _verticalAxis).normalized * _speed;
    }
}
