using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireMode
{
    public abstract int BulletConsumption { get; }
    public abstract float Firerate { get; }
    public abstract GunBase ThisBase { get; }
    public abstract void SetBase(GunBase pGunBase);
    public abstract void ChangeState(ShootStateBase pState);
    public abstract void ShootCommand();
}
