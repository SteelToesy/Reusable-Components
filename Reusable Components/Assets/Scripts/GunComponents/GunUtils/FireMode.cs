using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireMode : MonoBehaviour
{
    public abstract int BulletConsumption { get; }
    public abstract float Firerate { get; }
    public abstract GunBase ThisBase { get; }
    public abstract void Initialize(GunBase pGunBase);
    public abstract void Fire();
}
