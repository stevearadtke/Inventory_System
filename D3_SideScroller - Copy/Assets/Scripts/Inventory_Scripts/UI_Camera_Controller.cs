using UnityEngine;
using UnityEngine.UI;

public class UI_CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera uiCamera;
    public Canvas uiCanvas;

    void Start()
    {
        // Set the UI camera to look at the UI canvas.
        uiCamera.transform.LookAt(uiCanvas.transform);
    }

    void ActivateUICamera()
    {
        // Disable the main camera and enable the UI camera.
        mainCamera.enabled = false;
        uiCamera.enabled = true;
    }

    void DeactivateUICamera()
    {
        // Disable the UI camera and enable the main camera.
        uiCamera.enabled = false;
        mainCamera.enabled = true;
    }
}
