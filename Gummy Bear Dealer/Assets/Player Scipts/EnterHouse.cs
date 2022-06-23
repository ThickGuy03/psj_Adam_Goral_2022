using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Spawn;
    [SerializeField] public GameObject EnterH;
    private int triger;

    public void OnTriggerEnter(Collider other)
    {
        triger = 1;
    }
    public void OnTriggerExit(Collider other)
    {
        triger = 0;
    }
    public void Update()
    {
        if(triger==1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterH.SetActive(false);
                Spawn.SetActive(true);
                Player.transform.position = Spawn.transform.position;
            }
        }
    }
}
