using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    void Update()
        => Aim();

    void Aim()
    {
        var angle = Mathf.Atan2(AimDirection().y, AimDirection().x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    Vector3 AimDirection()
        => Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
}
