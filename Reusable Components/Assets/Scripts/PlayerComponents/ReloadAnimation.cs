using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAnimation : MonoBehaviour
{
    [SerializeField] private GunHandler _gunhandler;
    [SerializeField] private Transform _gunObjectTransform;

    private void Awake()
    {
        _gunhandler = GetComponentInParent<GunHandler>();
    }
    void Start()
    {
        if (!_gunhandler)
            Debug.Log("Gunhandler needed for this component");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
