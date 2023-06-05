using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private int _currentGun;
    [SerializeField] private Component[] _guns;

    //Add a gun to the array and turn one gun off while using the other

    public void AddGun(GunBase pGunBase)
    {
        gameObject.AddComponent(pGunBase.GetType());
        for (int i = 0; i < _guns.Length; i++)
        {
            if (_guns[i] == null)
            {
                _guns[i] = GetComponent(pGunBase.GetType());
                break;
            }
            else
                ReplaceGun(pGunBase);
            pGunBase.ConnectToPlayer();
        }

    }

    public void ReplaceGun(Component pGunBase) 
        => _guns[_currentGun] = GetComponent(pGunBase.GetType());
}
