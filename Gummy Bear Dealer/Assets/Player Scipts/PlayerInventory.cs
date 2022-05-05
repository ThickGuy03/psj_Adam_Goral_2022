using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{   
    public InventoryObject inventory;
    [Header("Open inventory")]
    public GameObject inv;
    public GameObject quest;
    bool pressed = false;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            pressed = !pressed;
            if(pressed==false)
            {
                inv.SetActive(pressed);
                quest.SetActive(!pressed);
                
                
            }
            if(pressed==true)
            {
                inv.SetActive(pressed);
                quest.SetActive(!pressed);
                
            }
        }
    }
}
