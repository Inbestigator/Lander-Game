using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public Text difficultyText; // The UI Text object to display the difficulty level
    private Scrollbar scrollbar;
    public float difficulty = 1;
    public Transform rocket;
    public Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(startButtonClicked);
        scrollbar = GetComponent<Scrollbar>();
    }

    public void OnScroll()
    {
        difficulty = scrollbar.value * 10 + 1;
        if (difficulty > 10)
        {
            difficulty = 20;
        }
        difficultyText.text = "Difficulty: " + difficulty.ToString("F0") + "x"; // Display difficulty level with 1 decimal point
    }

    public void startButtonClicked()
    {
        rocket.position = new Vector3(0, (80 * difficulty), (-20 * difficulty));
    }
}
