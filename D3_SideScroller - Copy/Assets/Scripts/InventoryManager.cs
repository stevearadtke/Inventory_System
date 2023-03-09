using EasyInventory.ServicesInterface;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Inventory inventory;

    private void Awake()
    {
        // Singleton pattern - ensure there is only one instance of this object.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        // Create a new inventory with size 24.
        inventory = new Inventory(24);
    }
}
