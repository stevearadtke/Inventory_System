using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInventory.ServicesInterface;
using EasyInventory.Processors;

public class GameManager : MonoBehaviour
{
    public Inventory inventory;  // The Inventory instance

    public GameObject pickableItemPrefab;  // The prefab for the pickable item object


    private void Awake()
    {
        // Create the inventory manager object.
        var inventoryManagerGO = new GameObject("Inventory Manager");
        inventoryManagerGO.AddComponent<InventoryManager>();
        DontDestroyOnLoad(inventoryManagerGO);
    }

    // Create an instance of the ItemProcessorInfo class
    ///ItemProcessorInfo itemProcessor = new ItemProcessorInfo();

    // Set the item processor for the inventory instance
    ///inventory.itemProcessor = itemProcessor;

    void SpawnPickableItem()
    {
        // Instantiate a pickable item object from the prefab
        GameObject pickableItemObject = Instantiate(pickableItemPrefab, transform.position, Quaternion.identity);

        // Get the Pickable_Item script component from the pickable item object
        Pickable_Item pickableItemScript = pickableItemObject.GetComponent<Pickable_Item>();

        // Assign the Inventory instance to the pickable item object's inventory variable
        pickableItemScript.inventory = inventory;
    }
}
