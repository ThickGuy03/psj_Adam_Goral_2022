using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
    public GameObject agent;
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
       if(destPoints==points.Length)
        {
            Destroy(agent,0.2f);
            Debug.Log("destroyed");
            return;
        }
       if(points.Length==0)
       {
            return;
       }

        navMeshAgent.destination = points[destPoints].position;

        destPoints++;
    }

    private void Update()
    {
        if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.2f)
        {
            GoToNextPosition();
        }
        
           
       
    }
}
