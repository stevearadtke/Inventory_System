/* This class manages all mouse over hover details and displays them in the view.
 * Author: Corey St-Jacques
 * Date: May 25, 2017
 */

using EasyInventory.Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages all mouse over hover details and displays them in the view.
/// </summary>
public class InfoManager : MonoBehaviour
{
    /// <summary>
    /// This is the current information instance.
    /// </summary>
    public static InfoManager Instance;

    /// <summary>
    /// This contains the associated Text view. I will prob want to swap it to TMP
    /// </summary>
    public Text infoTextL;

    //The info and mouse offset
    public float offset = 0.5f;



    /// <summary>
    /// This method is automatically initialized.
    /// </summary>
    private void Start ()
    {
        Instance = this;
	}


    public void MoveTextBox()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the new position for the parent object using the offset distance
        Vector3 newPos = new Vector3(mousePos.x + offset, mousePos.y + offset, transform.position.z);

        // Set the position of the parent object to the new position
        transform.position = newPos;


    }



    /// <summary>
    /// Sets the current details of the designated item to the screen view.
    /// </summary>
    /// <param name="item">The item to display.</param>
	public void SetDetails(Item item)
    {
        if (item != null)
        {
            InventoryItem inventoryItem
                = ItemRepository.Instance.GetInventoryItem(item);
            infoTextL.text = SetYellow(inventoryItem.itemName) 
                + CheckAmount(item.ItemAmount) + " "+inventoryItem.itemDescription;
        }
        else
            infoTextL.text = string.Empty;

    }

    /// <summary>
    /// Checks if the amount is greater than 1, and converts it to a compressed string numerical value.
    /// </summary>
    /// <param name="amount">The amount to convert.</param>
    /// <returns>Returns the converted numerical string.</returns>
    private string CheckAmount(int amount)
    {
        string result = string.Empty;
        if (amount > 1)
        {
            result = SetRed("(")
                + SetGreen(string.Format("{0:n0}", amount))
                + SetRed(")");
        }
        return result;
    }

    /// <summary>
    /// Sets the current string to red.
    /// </summary>
    /// <param name="text">The text to edit.</param>
    /// <returns>Returns the edited string.</returns>
    private string SetRed(string text)
    {
        return "<Color=red>" + text + "</Color>";
    }

    /// <summary>
    /// Sets the current string to green.
    /// </summary>
    /// <param name="text">The text to edit.</param>
    /// <returns>Returns the edited string.</returns>
    private string SetGreen(string text)
    {
        return "<Color=#84ff00>" + text + "</Color>";
    }

    /// <summary>
    /// Sets the current string to yellow.
    /// </summary>
    /// <param name="text">The text to edit.</param>
    /// <returns>Returns the edited string.</returns>
    private string SetYellow(string text)
    {
        return "<Color=#FFF800FF>" + text + "</Color>";
    }
}
