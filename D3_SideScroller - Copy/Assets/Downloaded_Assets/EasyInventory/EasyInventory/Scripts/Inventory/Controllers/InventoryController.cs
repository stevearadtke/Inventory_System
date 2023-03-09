using EasyInventory.ServicesInterface;
using EasyInventory.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInventory.Repository;

/// <summary>
/// Controller for managing the unity inventory view.
/// </summary>


public class InventoryController : InventoryInfoController
{
    public static new InventoryInfoController Instance;

    public InventoryInfo _myInventory;


    public static EquipmentInventory myEquipmentInventory; // Add this field





    /// <summary>
    /// Inventory instance.
    /// </summary>
    public override InventoryInfo MyInventory
    {
        get
        {
            return _myInventory;
        }
        set
        {
            _myInventory = value;
        }
    }

    // Use this for initialization
    private void Start()
    {


        Instance = this;
        MyInventory = new Inventory(transform.childCount);

        
        myEquipmentInventory = new EquipmentInventory(9, 9); // Create a new instance of EquipmentInventory

        LoadInventory();
        Debug.Log(myEquipmentInventory);


        
        
    }

    public override void LoadInventory()
    {
        try
        {
            byte[] fileData = IO.ReadFile(Application.dataPath + "/" + fileName);
            MyInventory = (Inventory)IO.ByteArrayToObject(fileData);
        }
        catch
        {
            SaveInventory();
        }
        UpdateInventory();
    }
}
