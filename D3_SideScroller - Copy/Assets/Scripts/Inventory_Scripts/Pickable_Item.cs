using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using EasyInventory.ServicesInterface;
using EasyInventory.Repository;
using EasyInventory.Processors;
using EasyInventory.Utils;
using EasyInventory.Factories;
using EasyInventory.Exceptions;


public class Pickable_Item : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField] public InventoryItem inventoryItem; // Reference to the ScriptableObject that represents the item

    private void Start()
    {


       // Debug.Log(InventoryController.myEquipmentInventory);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            //GameObject Equipment_Slots = GameObject.Find("Equipment_Slots");
            //InventoryInfoController inventoryController = Equipment_Slots.GetComponentInChildren<InventoryInfoController>();

            GameObject oInventory = GameObject.Find("Inventory");
            InventoryInfoController inventoryController = oInventory.GetComponentInChildren<InventoryInfoController>();


            //This finds the first instance of the InventoryInfoController. 
            //InventoryInfoController inventoryController = FindObjectOfType<InventoryInfoController>();

            if (inventoryController != null)
            {

                Item newItem = ItemFactory.CreateItem(inventoryItem.itemId, 1, inventoryItem.stackable, inventoryItem.icon);
                
                InventoryInfo myInventory = inventoryController.MyInventory;
                myInventory.AddItem(newItem);


                //InventoryInfo myInventory = InventoryController.myEquipmentInventory;
               // myInventory.AddItem(newItem);

                
                Debug.Log(myInventory);


                FindObjectOfType<InventoryController>().UpdateInventory();
                Destroy(gameObject);
            }
        }
    }
}