using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    protected PlayerInput _playerInput;

    protected Texture2D _texture;
    protected Transform _bulletSpawnpoint;
    protected GameObject _bullet;

    protected float _damage;
    protected float _firerate;
    protected float _reloadTime;

    protected float _maxAmmo;
    protected float _ammo;

    private void Update()
    {
        Shoot();
    }

    public void ConnectToPlayer(GameObject pBullet)
    {
        _playerInput = GetComponent<PlayerInput>();
        _bulletSpawnpoint = GetComponentInChildren<Transform>();
        _bullet = pBullet;
    }

    public void Shoot()
    {
        if (_playerInput.Fire <= 0)
            return;

        if (_ammo == 0)
            Reload();
        else
            Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
    }

    void Reload()
    {
        _ammo = _maxAmmo;
    }
}
