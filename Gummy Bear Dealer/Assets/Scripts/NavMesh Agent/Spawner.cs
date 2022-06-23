using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 SpawnPos;
    [SerializeField] public GameObject[] spawnObject;
    [SerializeField] public Transform[] destPosition;
    private float rSpeedDuration;
    private float min = 3f;
    private float max = 10f;


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
    public void Update()
    {
       rSpeedDuration = Random.Range(min, max);
    }
    void SpawnNewObject()
    {
        int option = Random.Range(0, spawnObject.Length);
        Instantiate(spawnObject[option], SpawnPos, Quaternion.identity);
        if(spawnObject[option].tag=="Car")
        {
            spawnObject[option].GetComponent<AINavMesh>().minSpeed = 20f;
            spawnObject[option].GetComponent<AINavMesh>().maxSpeed = 45f;
            spawnObject[option].GetComponent<AINavMesh>().minAcc = 7f;
            spawnObject[option].GetComponent<AINavMesh>().maxAcc = 15f;
            spawnObject[option].GetComponent<AINavMesh>().rangeFromPoint = 2f;
            min = 25f;
            max = 60f;
        }
        NewSpawnRequest();
    }

    public void NewSpawnRequest()
    {
            Invoke("SpawnNewObject", rSpeedDuration);
    }
}