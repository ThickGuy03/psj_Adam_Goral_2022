using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 SpawnPos;
    [SerializeField] public GameObject[] spawnObject;
    [SerializeField] public float newSpawnDuration = 120f;
    [SerializeField] public Transform[] destPosition;
    int numberOfSpawned = 0;

    #region Singleton
    public static Spawner Instance;

    private void Awake()
    {
        Instance = this;

    }

    #endregion

    private void Start()
    {
        SpawnPos = transform.position;
        NewSpawnRequest();
    }
    
    void SpawnNewObject()
    {
        int option = Random.Range(0, spawnObject.Length);
        Instantiate(spawnObject[option], SpawnPos, Quaternion.identity);
        for (int i = 0; i < destPosition.Length; i++)
        {
            spawnObject[option].GetComponent<AINavMesh>().points[i] = destPosition[i];
        }
        NewSpawnRequest();
    }

    public void NewSpawnRequest()
    {
        if(numberOfSpawned==0)
        {
            Invoke("SpawnNewObject", 1f);
            numberOfSpawned++;
        }
        else
        {
            Invoke("SpawnNewObject",newSpawnDuration);
        }
    }
}
