using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 target;
    private Vector3 mousePos;
    private Vector3 refVel;

    //private float cameraDist = 3.5f;

    private float smoothTime = 0f; //zStart;

    void Start()
    {
        target= player.position;
        //zStart = transform.position.z;
    }

    void Update()
    {
        mousePos = CaptureMousePos();
        target = UpdateTargetPos();
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);
    }

    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        //float max = 0.9f;
        //if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        //{
        //    ret = ret.normalized;
        //}
        return ret;
    }

    Vector3 UpdateTargetPos()
    {
        //Vector3 mouseOffset = mousePos * cameraDist;
        Vector3 ret = player.position + mousePos; //+ mouseOffset;
        //ret.z = zStart;
        return ret;
    }
}
