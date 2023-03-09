using EasyInventory.Factories;
using EasyInventory.Processors;
using EasyInventory.Repository;
using System;
using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;

namespace EasyInventory.ServicesInterface
{
    [Serializable]
    public class EquipmentInventory : InventoryInfo
    {


        public static EquipmentInventory Instance;
        public EquipmentSlot[] equipmentSlots;




        public EquipmentInventory(int size, int equipmentSlotsCount) : base(size)
        {
            itemProcessor = new InventoryProcessor(); // Add this line to initialize itemProcessor
            equipmentSlots = new EquipmentSlot[equipmentSlotsCount];
            for (int i = 0; i < equipmentSlotsCount; i++)
            {
                equipmentSlots[i] = new EquipmentSlot();
            }
        }



        public bool AddItemToEquipmentSlots(Item item)
        {
            EquipmentSlot slot = FindEmptySlot(item.ItemType);
            if (slot != null)
            {
                slot.CurrentItem = item;
                return true;
            }
            return false;
        }

        public bool RemoveItem(ItemType itemType)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].CurrentItem != null && equipmentSlots[i].CurrentItem.ItemType == itemType)
                {
                    equipmentSlots[i].CurrentItem = null;
                    return true;
                }
            }
            return false;
        }

        private EquipmentSlot FindEmptySlot(ItemType itemType)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].CurrentItem == null && equipmentSlots[i].ItemType == itemType)
                {
                    return equipmentSlots[i];
                }
            }
            return null;
        }

        public override string ToString()
        {
            string result = "Equipment Inventory: [ ";
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].CurrentItem != null)
                {
                    result += equipmentSlots[i].CurrentItem.ItemType.ToString() + " ";
                }
                else
                {
                    result += "NULL ";
                }
            }
            result += "]";
            return result;
        }
    }

}
