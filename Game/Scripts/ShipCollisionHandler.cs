using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipCollisionHandler : MonoBehaviour
{
    // public Vector3 respawnPosition = new Vector3(0, 10, 0); // Customize this to your desired respawn position
    public Button winButton;
    public Canvas screen;
    public Canvas display;
    public RocketController controls;
    public cameraSwitcher cameras;
    public ShipCollisionHandler winScript; 
    public Displays Displays;

    void Start()
    {
        winButton.onClick.AddListener(winButtonClicked);
        screen.enabled = false;
        controls.enabled = true;
        cameras.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            RespawnRocket();
            screen.enabled = true;
            Displays.timeScale = 1f;
            // controls.enabled = false;
            // cameras.enabled = false;
            // GetComponent<Rigidbody>().isKinematic = true;        
        }
    }

    private void RespawnRocket()
    {
        Rigidbody rocketRigidbody = GetComponent<Rigidbody>();
        rocketRigidbody.velocity = Vector3.zero;
        rocketRigidbody.angularVelocity = Vector3.zero;
        // transform.position = respawnPosition;
        // transform.rotation = Quaternion.identity;
    }

    void winButtonClicked()
    {
        screen.enabled = false;
        // display.enabled = true;
        controls.enabled = true;
        cameras.enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        Displays.timeScale = 1f;
        cameras.camera1.enabled = false;
        cameras.camera2.enabled = false;
        cameras.camera3.enabled = true;
    }

}
