using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoFirering : ShootStateBase
    {
        private bool firering = false;
        public override void UpdateState(FireMode pFireMode)
        {
            StartCoroutine(Delay(pFireMode));
            if (firering)
                pFireMode.ChangeState(pFireMode.CanfireState);
        }

        private IEnumerator Delay(FireMode pFireMode)
        {
            yield return new WaitForSeconds((60 / pFireMode.Firerate));
            firering = true;
        }
    }
