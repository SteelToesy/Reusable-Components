using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireMode : MonoBehaviour
{
    public abstract int BulletConsumption { get; }
    public abstract float Firerate { get; }
    public abstract GunBase ThisBase { get; }
    public abstract ShootStateBase CanfireState { get; }
    public abstract ShootStateBase FireringState { get; }

    public abstract void SetBase(GunBase pGunBase);

    public abstract void Initialize();
    public abstract void ChangeState(ShootStateBase pState);
    public abstract void UpdateState();
}
