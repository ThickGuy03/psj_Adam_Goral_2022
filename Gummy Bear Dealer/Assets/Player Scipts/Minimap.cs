using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject PlayerObj;
    public GameObject CarObj;
    public Transform player;
    public Transform car;

    void LateUpdate()
    {
        if(PlayerObj.activeSelf)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
        else
        {
            Vector3 newPosition = car.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90f, car.eulerAngles.y, 0f);
        }
    }
}
