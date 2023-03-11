using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OceanCollisionHandler : MonoBehaviour
{
    public Transform Ship;
    public Vector3 respawnPosition; // Customize this to your desired respawn position
    public Button respawnButton;
    public Canvas screen;
    public Canvas display;
    public RocketController controls;
    public cameraSwitcher cameras;

    public Displays Displays;
    public Difficulty difficulty;

    void Start()
    {
        respawnButton.onClick.AddListener(respawnButtonClicked);
        screen.enabled = false;
        controls.enabled = true;
        cameras.enabled = true;
    }

    void Update()
    {
        Cursor.visible = true;
        respawnPosition = new Vector3(Ship.position.x, ((Ship.position.y + 80) * difficulty.difficulty), ((Ship.position.z - 20) * difficulty.difficulty));

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ocean"))
        {
            RespawnRocket();
            screen.enabled = true;
            display.enabled = false;
            controls.enabled = false;
            cameras.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;   
            // respawnPosition = new Vector3(Ship.x, (Ship.y + 80), (Ship.z - 20));
        }
    }

    private void RespawnRocket()
    {
        Rigidbody rocketRigidbody = GetComponent<Rigidbody>();
        rocketRigidbody.velocity = Vector3.zero;
        rocketRigidbody.angularVelocity = Vector3.zero;
        transform.position = respawnPosition;
        transform.rotation = Quaternion.identity;
    }

    public void respawnButtonClicked()
    {
        screen.enabled = false;
        display.enabled = true;
        controls.enabled = true;
        cameras.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        Displays.timeScale = 1f;
        controls.throttle = 0.0f;
    }

}
