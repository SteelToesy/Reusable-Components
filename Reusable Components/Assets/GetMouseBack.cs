using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMouseBack : MonoBehaviour
{
    [SerializeField] private bool _mouse;
    private void Awake()
    {
        Cursor.visible = _mouse;
    }
}
