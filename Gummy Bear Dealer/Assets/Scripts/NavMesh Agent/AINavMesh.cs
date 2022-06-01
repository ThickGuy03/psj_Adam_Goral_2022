using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
    public Transform[] points;
    private int destPoints=0;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();

        GoToNextPosition();
    }

    void GoToNextPosition()
    {
       if(points.Length==0)
       {
            return;
       }

        navMeshAgent.destination = points[destPoints].position;

        destPoints = (destPoints + 1) % points.Length;
    }

    private void Update()
    {
        if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.2f)
        {
            GoToNextPosition();
        }
    }
}
