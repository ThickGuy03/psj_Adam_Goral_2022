using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
    public GameObject agent;
    public Transform[] points;
    public GameObject spawner;
    private int destPoints = 0;
    private NavMeshAgent navMeshAgent;
    public float minSpeed = 3f;
    public float maxSpeed = 8f;
    public float minAcc = 1.5f;
    public float maxAcc = 3.5f;
    public float rangeFromPoint = 2f;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        float rSpeed = UnityEngine.Random.Range(minSpeed, 8f);
        float rAcceleration = UnityEngine.Random.Range(1.5f, 3.5f);
        
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");//Zczytywanie wszystkich istniejących obiektów z tagiem Spawner
        foreach(GameObject x in spawners) //Znajdowanie pozycji najbliższego spawnera
        {
            if(agent.transform.position==x.transform.position)
            {
                spawner = x;
                points = x.GetComponent<Spawner>().destPosition;//Przypisanie ściezki spawnera do agenta
            }
        }
        navMeshAgent.speed = rSpeed;
        navMeshAgent.acceleration = rAcceleration;
        GoToNextPosition();
    }
    private void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < rangeFromPoint)
        {
            GoToNextPosition();
        }
    }
    void GoToNextPosition()
    {
        if (destPoints == points.Length)
        {
            Destroy(agent, 2f);
            return;
        }
        if (points.Length == 0)
        {
            return;
        }

        navMeshAgent.destination = points[destPoints].transform.position;

        destPoints++;
    }

}