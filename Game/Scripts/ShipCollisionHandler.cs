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
    public Canvas Lose;
    public GameObject Ship;
    public Transform Rocket;
    public DirtController Dust;

    void Start()
    {
        winButton.onClick.AddListener(winButtonClicked);
        screen.enabled = false;
        controls.enabled = true;
        cameras.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship") && Displays.speed < 25)
        {
            RespawnRocket();
            screen.enabled = true;
            Displays.timeScale = 1f;   
        } else if (collision.gameObject.CompareTag("Ship") && Displays.speed > 25)
        {
            Ship.tag = "Ocean";
        } else if (collision.gameObject.CompareTag("Ship") && Rocket.rotation.x > 15)
        {
            Ship.tag = "Ocean";
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
        cameras.currentCameraIndex = 2;
        Dust.dirt.Stop();
    }
}
