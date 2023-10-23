using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        SpriteControl();
        Aim();
    }

    void Aim()
    {
        var angle = Mathf.Atan2(AimDirection().y, AimDirection().x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    Vector3 AimDirection()
        => Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

    void SpriteControl()
    {
        float rot = transform.rotation.eulerAngles.z -90;
            
        if (rot >= 0 && rot <= 180)
            _spriteRenderer.flipY = true;
        else 
            _spriteRenderer.flipY = false;
    }
}
