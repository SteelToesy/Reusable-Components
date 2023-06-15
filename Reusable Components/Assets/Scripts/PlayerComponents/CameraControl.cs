using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float lerp;

    private Vector3 target;
    private Vector3 mousePos;
    private Vector3 refVel;
    private float zStart;


    void Start()
    {
        target = player.position;
        zStart = transform.position.z;
    }

    void Update()
    {
        mousePos = UpdateMousePos();
        target = UpdateTargetPos();
        target.z = zStart;

        UpdateCameraPosition();
    }

    void UpdateCameraPosition() 
        => transform.position = Vector3.SmoothDamp(transform.position, target, ref refVel, lerp);

    Vector3 UpdateMousePos() 
        => Camera.main.ScreenToViewportPoint(Input.mousePosition);
    
    Vector3 UpdateTargetPos() 
        => player.position + mousePos;
}
