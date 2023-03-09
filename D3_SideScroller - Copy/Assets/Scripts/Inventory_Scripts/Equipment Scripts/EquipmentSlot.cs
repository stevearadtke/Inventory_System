




using EasyInventory.Repository;
using EasyInventory.Factories;
using System;

//namespace EasyInventory.ServicesInterface
namespace EasyInventory.Repository
{

    [Serializable]
    /// <summary>
    /// This class represents a single slot in the equipment inventory.
    /// </summary>
    public class EquipmentSlot
    {
        private Item _currentItem;

        public Slot slot = SlotFactory.CreateSlot();

        public ItemType ItemType { get; set; }


        /// <summary>
        /// The current attached item.
        /// </summary>
        public Item CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                _currentItem = value;
            }
        }

        public Item GetCurrentItem()
        {
            return slot.CurrentItem;
        }


        /// <summary>
        /// Adds an item to the current slot.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(Item item)
        {
            if (IsEmpty())
            {
                SetItem(item);
                return;
            }

            if (CurrentItem.ItemId != item.ItemId)
                return;

            CurrentItem.ItemAmount += item.ItemAmount;
        }

        /// <summary>
        /// Sets the current item to the current slot.
        /// </summary>
        /// <param name="item">The current item.</param>
        public void SetItem(Item item)
        {
            slot.SetItem(item);

            _currentItem = item;

        }


        /// <summary>
        /// Clears the current item.
        /// </summary>
        /// <returns>Returns the item to see if it has been cleared successfully.</returns>
        public Item Clear()
        {
            slot.Clear();

            Item item = _currentItem;
            _currentItem = null;
            return item;
        }

        /// <summary>
        /// Checks if the slot is empty or not.
        /// </summary>
        /// <returns>Returns true if the the slot is empty.</returns>
        public bool IsEmpty()
        {
            return slot.IsEmpty();
            //Im not sure what to do about that warning, I want to see what double dipping would do since calling it like this removed me errors in my EquipmentInventory Script. IDK
            return (_currentItem == null);
        }

        /// <summary>
        /// Clones the current slot.
        /// </summary>
        /// <returns>Returns the new slot instance.</returns>
        public EquipmentSlot Clone()
        {
            EquipmentSlot tmpSlot = new EquipmentSlot();
            if (!IsEmpty())
                tmpSlot._currentItem =
                    ItemFactory.CreateItem(_currentItem.ItemId,
                        _currentItem.ItemAmount,
                        _currentItem.Stackable, 
                        _currentItem.Icon);
            else
                tmpSlot._currentItem = null;
            return tmpSlot;
        }

        /// <summary>
        /// Converts the current instance to a readable string.
        /// </summary>
        /// <returns>The resulting string.</returns>
        public override string ToString()
        {
            string result = string.Empty;
            if (_currentItem != null)
                result += _currentItem;
            else
                result += "NULL";

            return result;
        }
    }
}
