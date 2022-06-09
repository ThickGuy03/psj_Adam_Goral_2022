using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCar : MonoBehaviour
{
    public GameObject CarCamera;
    public GameObject Player;
    public GameObject ExitTrigger;
    public GameObject TheCar;
    public GameObject ExitPlace;
    public GameObject Waypoint;

    private void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Player.SetActive(true);
            Player.transform.position = ExitPlace.transform.position;
            CarCamera.SetActive(false);
            TheCar.GetComponent<CarContoller>().enabled = false;
            ExitTrigger.SetActive(false);
            Waypoint.SetActive(true);
        }
    }
}
