using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    public Displays Displays;
    public Button restart;
    public OceanCollisionHandler Ocean;
    public Transform Rocket;
    public Rigidbody rb;
    public Canvas start;
    public Canvas ship;
    public Canvas ocean;
    public RocketController control;
    public Canvas display;

    private bool isPaused = false;

    void Start()
    {
        restart.onClick.AddListener(restartClicked);
    }

    private void Update()
    {
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (start.enabled == false && ocean.enabled == false)
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        Displays.timeScale = 0;
        pauseMenu.enabled = true;
        isPaused = true;
        control.enabled = false;
        display.enabled = false;
        ship.enabled = false;
    }

    public void ResumeGame()
    {
        Displays.timeScale = 1;
        pauseMenu.enabled = false;
        isPaused = false;
        control.enabled = true;
        display.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void restartClicked()
    {
        Displays.timeScale = 1f;
        pauseMenu.enabled = false;
        Rocket.transform.position = Ocean.respawnPosition;
        Rocket.transform.rotation = Quaternion.identity;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
