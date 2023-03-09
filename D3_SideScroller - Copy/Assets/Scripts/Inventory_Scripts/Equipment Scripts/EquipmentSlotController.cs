using UnityEngine;
using UnityEngine.UI;
using EasyInventory.ServicesInterface;
using EasyInventory.Factories;
using EasyInventory.Processors;
using EasyInventory.Repository;
using System;
using System.Diagnostics;
using System.Collections.Generic;

public class EquipmentSlotController : MonoBehaviour
{


    public Image icon;
    public Button removeButton;

    private EquipmentSlot _slot;

    public void AddItem(EquipmentSlot slot)
    {
        _slot = slot;

        icon.sprite = _slot.GetCurrentItem().Icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _slot = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        EquipmentInventory.Instance.RemoveItem(_slot.ItemType);
        ClearSlot();
    }

    public void OnItemClick()
    {
        // You can add custom behavior here for when an item in the equipment inventory is clicked
    }
}
