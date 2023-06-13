using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, IPickupable
{
    [SerializeField] private GunBase _gun;
    [SerializeField] private Sprite _gunTexture;

    void Start() 
    { 
        _gun = GetComponent<GunBase>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GunHandler>() != null)
        {
            var handler = collision.GetComponent<GunHandler>();
            handler.AddGun(_gun, _gunTexture);
            Destroy(this.gameObject);
        }
    }
}
