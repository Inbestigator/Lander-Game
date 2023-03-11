using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class cameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;
    [SerializeField]
    public int currentCameraIndex = 0;

    [SerializeField]
    public InputActionReference indexDown;

    private void Start()
    {
        // Enable the first camera
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;

        indexDown.action.Enable();
    }

    private void Update()
    {
        // Toggle cameras on V key press
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentCameraIndex = (currentCameraIndex + 1) % 4;
        }

        switch (currentCameraIndex)
        {
            case 0:
                camera1.enabled = true;
                camera2.enabled = false;
                camera3.enabled = false;
                camera4.enabled = false;
                break;
            case 1:
                camera1.enabled = false;
                camera2.enabled = true;
                camera3.enabled = false;
                camera4.enabled = false;
                break;
            case 2:
                camera1.enabled = false;
                camera2.enabled = false;
                camera3.enabled = true;
                camera4.enabled = false;
                break;
            case 3:
                camera1.enabled = false;
                camera2.enabled = false;
                camera3.enabled = false;
                camera4.enabled = true;
                break;
        }

        // Zoom in/out on camera 2 using scroll wheel
        if (camera2.enabled == true)
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWheel != 0f)
            {
                camera2.fieldOfView = Mathf.Clamp(camera2.fieldOfView - scrollWheel * 10f, 1f, 100f);
            }
        }
    }
}
