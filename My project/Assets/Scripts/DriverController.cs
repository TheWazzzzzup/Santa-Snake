using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DriverController : MonoBehaviour
{

    [SerializeField] Transform Desination;

    [SerializeField] NavMeshAgent agent;

    [SerializeField] float Speed = 3.5f;

    private void Start()
    {
        agent.speed = Speed;
    }


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Desination.position);

        transform.LookAt(Desination.position);
    }
}
