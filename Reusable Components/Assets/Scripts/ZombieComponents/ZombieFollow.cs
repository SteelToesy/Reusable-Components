using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    NavMeshAgent agent;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _distanceTilStop;

    private void Awake()
    {
        _target = GameObject.Find("Player").transform; // very illegal, must change, pls don't forget. Ugly ass code.
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start(){
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update(){
        agent.SetDestination(_target.position);
    }

    // private void FixedUpdate()
    // {
    //     MoveToPlayer();
    // }

    // void MoveToPlayer()
    // {
    //     if (!CloseEnough())
    //         _rb.velocity = GetDirection().normalized * _speed;
    //     else _rb.velocity = Vector3.zero;
    // }

    // public Vector2 GetDirection()
    // {
    //     return _target.position - transform.position;
    // }

    // public bool CloseEnough() // serach for the closest player or zombie and stop if close enough
    // {
    //     float distance = Vector3.Distance(transform.position, _target.transform.position);
    //     if (distance > _distanceTilStop)
    //         return false;
    //     else 
    //         return true;
    // }
}
