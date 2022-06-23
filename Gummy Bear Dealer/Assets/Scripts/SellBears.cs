using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellBears : MonoBehaviour
{
    public InventoryObject Inventory;
    public GameObject dialogTxt;
    public GameObject cashTxt;
    private int triger;
    private int numberOfBears;
    private int finalAmount;
    private int totalCash=0;

    public void OnTriggerEnter(Collider other)
    {
        triger = 1;
    }
    public void OnTriggerExit(Collider other)
    {
        triger = 0;
        dialogTxt.SetActive(false);
    }
    void Update()
    {
        if (triger == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(Inventory.Container.Count==0)
                {
                    dialogTxt.GetComponent<Text>().text = "Are you dumb? I won't give u money for free!";
                }
                else
                {
                    dialogTxt.SetActive(true);
                    int option = Random.Range(0, Inventory.Container.Count);
                    if (Inventory.Container[option].amount == 0)
                    {
                        dialogTxt.GetComponent<Text>().text = "You have nothing interesting for me. Come back later.";
                    }
                    else
                    {
                        numberOfBears = Random.Range(1, Inventory.Container[option].amount + 1);
                        finalAmount = numberOfBears * Inventory.Container[option].item.value;
                        totalCash += finalAmount;
                        cashTxt.GetComponent<Text>().text = "Cash: " + totalCash.ToString();
                        dialogTxt.GetComponent<Text>().text = "I will give you " + finalAmount + " for your Bears.";
                        Inventory.Container[option].RemoveAmount(numberOfBears);
                    }
                }
            }
        }
    }
}
