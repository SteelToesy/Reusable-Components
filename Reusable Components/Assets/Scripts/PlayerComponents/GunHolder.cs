using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private int _currentGun;
    [SerializeField] private List<GunStats> _guns = new();

    void AddGun(GunStats pGunstats)
    {
        _guns.Add(pGunstats);
    }

    void RemoveGun(GunStats pGunstats)
    {
        _guns.Remove(pGunstats);
    }
}
