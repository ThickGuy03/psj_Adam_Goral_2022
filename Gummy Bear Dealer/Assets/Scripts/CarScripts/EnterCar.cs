using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
    public GameObject CarCamera;
    public GameObject Player;
    public GameObject ExitTrigger;
    public GameObject TheCar;
    public int TriggerCheck;

    public void OnTriggerEnter(Collider other)
    {
        TriggerCheck = 1;
    }
    public void OnTriggerExit(Collider other)
    {
        TriggerCheck = 0;
    }
    public void Update()
    {
        if(TriggerCheck==1)
        {
            if(Input.GetButtonDown("Action"))
            {
                CarCamera.SetActive(true);
                Player.SetActive(false);
                TheCar.GetComponent<CarContoller>().enabled=true;
                ExitTrigger.SetActive(true);
            }
        }
    }
}
