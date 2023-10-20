using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoCanfire : ShootStateBase
{
    public override void UpdateState(FireMode pFireMode)
    {
        pFireMode.ThisBase.BulletsFired(pFireMode.BulletConsumption);
        pFireMode.ThisBase.SpawnBullet();
        pFireMode.ChangeState(pFireMode.FireringState);
    }
}
