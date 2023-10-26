using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GunHandler>())
            _door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
