using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField]protected PlayerInput _playerInput;

    [SerializeField]protected Texture2D _texture;
    [SerializeField]protected Transform _bulletSpawnpoint;
    [SerializeField]protected GameObject _bullet;

    [SerializeField]protected float _damage;
    [SerializeField]protected float _firerate;
    [SerializeField]protected float _reloadTime;

    [SerializeField]protected float _maxAmmo;
    [SerializeField]protected float _ammo;

    public virtual void ConnectToPlayer()
    {
        _playerInput = GetComponent<PlayerInput>();
        _bulletSpawnpoint = GetComponentInChildren<Transform>();
    }

    public virtual void Shoot()
    {
        Debug.Log("reach");
        if (_playerInput.Fire <= 0)
            return;

        if (_ammo <= 0)
            Reload();
        else
            Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
    }

    public virtual void Reload()
    {
        //TODO: reload fuction
        _ammo = _maxAmmo;
    }
}
