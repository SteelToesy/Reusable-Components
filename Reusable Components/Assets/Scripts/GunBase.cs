using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    protected Texture2D _texture;
    protected Transform _bulletSpawnpoint;
    protected GameObject _bullet;

    protected float _damage;
    protected float _firerate;
    protected float _reloadTime;

    protected float _maxAmmo;
    protected float _ammo;

    void ConnectWeapon()
    {

    }

    public void Shoot()
    {
        if (_ammo == 0)
            Reload();
        Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
    }

    void Reload()
    {

    }
}
