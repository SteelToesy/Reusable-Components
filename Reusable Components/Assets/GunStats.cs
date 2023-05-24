using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    [SerializeField] private float _damage;
    [SerializeField] private float _firerate;

    [SerializeField] private float _reloadTime;
    [SerializeField] private float _maxAmmo;
    [SerializeField] private float _ammo;
}
