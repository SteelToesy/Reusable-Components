using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _currentGun;
    [SerializeField] private List<GunBase> _guns = new();

    private void Start()
    {
        AddGun(gameObject.AddComponent<Pistol>());
    }

    void AddGun(GunBase pGunBase)
    {
        for (int i = 0; i < _guns.Count; i++)
            if (_guns[i] == null)
            {
                _guns[i] = pGunBase;
                break;
            }
            else
                ReplaceGun(pGunBase);
        pGunBase.ConnectToPlayer(_bulletPrefab);
    }

    void ReplaceGun(GunBase pGunBase) 
        => _guns[_currentGun] = pGunBase;

    public void Shoot()
        => _guns[_currentGun].Shoot();
}
