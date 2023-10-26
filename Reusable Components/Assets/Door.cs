using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    [SerializeField] private GameObject _waveManager;
    [SerializeField] private GameObject _tutorial;
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GunHandler>())
        {
            _waveManager.SetActive(true);
            _tutorial.SetActive(false);
            _door.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
