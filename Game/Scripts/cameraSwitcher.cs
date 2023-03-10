using UnityEngine;
using UnityEngine.UI;

public class cameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    [SerializeField]
    public int currentCameraIndex = 0;

    private void Start()
    {
        // Enable the first camera
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
    }

    private void Update()
    {
        // Toggle cameras on V key press
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentCameraIndex = (currentCameraIndex + 1) % 3;
        }

        switch (currentCameraIndex)
        {
            case 0:
                camera1.enabled = true;
                camera2.enabled = false;
                camera3.enabled = false;
                break;
            case 1:
                camera1.enabled = false;
                camera2.enabled = true;
                camera3.enabled = false;
                break;
            case 2:
                camera1.enabled = false;
                camera2.enabled = false;
                camera3.enabled = true;
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
