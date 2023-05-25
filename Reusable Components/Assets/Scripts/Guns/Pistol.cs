using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GunBase
{
    [SerializeField] private Transform _pistolBulletSpawn;
    [SerializeField] private Texture2D _pistolTexture;
    [SerializeField] private GameObject _pistolBullet;

    [SerializeField] private float _pistolDamage;
    [SerializeField] private float _pistolFirerate;
    [SerializeField] private float _pistolReloadTime;

    [SerializeField] private float _pistolMaxAmmo;
    public Pistol()
    {
        _texture = _pistolTexture;
        _damage = _pistolDamage;
        _firerate = _pistolFirerate;
        _reloadTime = _pistolReloadTime;

        _maxAmmo = _pistolMaxAmmo;
        _bulletSpawnpoint = _pistolBulletSpawn;
        _bullet = _pistolBullet;
    }
}
