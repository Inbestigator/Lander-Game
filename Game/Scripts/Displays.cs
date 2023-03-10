using UnityEngine;
using UnityEngine.UI;

public class Displays : MonoBehaviour
{
    public Text positionText;
    public Text throttleText;
    public Text timeScaleText;

    public Button timeScaleButton1;
    public Button timeScaleButton2;
    public Button timeScaleButton3;

    public Text speedText;
    private Rigidbody rb;

    private RocketController rocketController;
    public float timeScale = 1f;

    public float speed;

    void Start()
    {
        rocketController = FindObjectOfType<RocketController>();
        timeScaleButton1.onClick.AddListener(SetTimeScale1);
        timeScaleButton2.onClick.AddListener(SetTimeScale2);
        timeScaleButton3.onClick.AddListener(SetTimeScale3);
        rb = GameObject.FindWithTag("Rocket").GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateDisplays();
        speed = rb.velocity.magnitude;
        speedText.text = "Speed: " + speed.ToString("F1") + " m/s";
    }

    void SetTimeScale1()
    {
        timeScale = 0.5f;
    }

    void SetTimeScale2()
    {
        timeScale = 1f;
    }

    void SetTimeScale3()
    {
        timeScale = 10f; 
    }

    private void UpdateDisplays()
    {
        // Position
        Vector3 pos = rocketController.transform.position;
        positionText.text = "X: " + pos.x.ToString("F0") + " | Y: " + pos.y.ToString("F0") + " | Z: " + pos.z.ToString("F0");

        // Throttle
        throttleText.text = "Throttle: " + (rocketController.GetThrottle() * 100).ToString("F0") + "%";

        Time.timeScale = timeScale;
        timeScaleText.text = "Time Scale: " + timeScale.ToString("F1") + "x";
    }

    public float Speed()
    {
        return speed;
    }
}
