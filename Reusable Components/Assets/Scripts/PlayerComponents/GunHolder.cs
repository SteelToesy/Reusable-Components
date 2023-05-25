using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private int _currentGun;
    [SerializeField] private GunBase[] _guns = new GunBase[2];

    private void Start()
    {
        _guns[0] = GetComponent<Pistol>();
    }

    void AddGun(GunBase pGunBase)
    {
        for (int i = 0; i < _guns.Length; i++)
            if (_guns[i] == null)
            {
                _guns[i] = pGunBase;
                break;
            }
            else
                ReplaceGun(pGunBase);
    }

    void ReplaceGun(GunBase pGunBase) 
        => _guns[_currentGun] = pGunBase;

    public void Shoot()
        => _guns[_currentGun].Shoot();
}
