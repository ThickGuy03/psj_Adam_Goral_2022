using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
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
        if (triger == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterH.SetActive(true);
                Spawn.SetActive(false);
                Player.transform.position = EnterH.transform.position;
            }
        }
    }
}
