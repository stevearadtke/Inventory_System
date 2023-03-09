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
using System;

public class EquipmentManager : MonoBehaviour
{

    public EquipmentSlot weaponSlot;
    public EquipmentSlot helmetSlot;

 



    public EquipmentSlot GetEquipmentSlotForItemType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                return weaponSlot;
            case ItemType.Helmet:
                return helmetSlot;
            // Add cases for other item types as needed
            default:
                return null;
        }
    }


}
