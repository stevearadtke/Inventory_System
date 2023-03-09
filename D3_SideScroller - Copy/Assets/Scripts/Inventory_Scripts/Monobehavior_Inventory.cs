using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInventory.ServicesInterface;

public class Monobehavior_Inventory : MonoBehaviour
{
    //public Inventory inventory;

    void Awake()
    {
        
    }

    void Start()
    {
        // other methods that use the inventory instance
        // I can now call methods in the super secret inventory script and use them in the monobehvior namespace.
        // 
        var inventory = InventoryManager.instance.inventory;

    }
}
