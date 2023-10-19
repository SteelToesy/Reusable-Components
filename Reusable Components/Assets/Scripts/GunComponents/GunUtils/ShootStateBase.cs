using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootStateBase : MonoBehaviour
{
    public abstract void UpdateState(FireMode pFireMode);
}

