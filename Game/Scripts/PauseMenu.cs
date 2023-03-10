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

    private bool isPaused = false;

    void Start()
    {
        restart.onClick.AddListener(restartClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void PauseGame()
    {
        Displays.timeScale = 0;
        pauseMenu.enabled = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Displays.timeScale = 1;
        pauseMenu.enabled = false;
        isPaused = false;
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
    }
}
