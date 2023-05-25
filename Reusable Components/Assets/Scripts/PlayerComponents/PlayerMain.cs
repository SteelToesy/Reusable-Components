using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private PlayerInput _playerInput;
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
}
