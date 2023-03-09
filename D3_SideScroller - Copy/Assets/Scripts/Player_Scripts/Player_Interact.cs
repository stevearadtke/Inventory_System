using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player_Interact : MonoBehaviour
{
    public GameObject UI;

    //private bool _isPaused = false;


    void OnOpenInventory(InputValue value)
    {
        Canvas uiCanvas = UI.GetComponent<Canvas>();

        if (!uiCanvas.enabled)
        {
            uiCanvas.enabled = true;

            //_isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            uiCanvas.enabled = false;

            //_isPaused = false;
            Time.timeScale = 1;
            Debug.Log("Trying to open Inventory");
        }

    }

    void OnInteract(InputValue value)
    {

    }

}
