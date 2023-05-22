using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Health _health;

    private DirectionalMovement _directionalMovement;
    private Sprint _sprint;

    void Awake()
    {
        _health = GetComponent<Health>();

        _directionalMovement = GetComponent<DirectionalMovement>();
        _sprint = GetComponent<Sprint>();
    }
}
