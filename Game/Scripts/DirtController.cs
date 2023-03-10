using UnityEngine;

public class DirtController : MonoBehaviour
{
    public ParticleSystem dirt; // assign these in the Inspector
    public RocketController control;
    public float throttle;

    void Start()
    {
        dirt.Stop();
    }

    void Update()
    {
        throttle = control.throttle;
    }

    private void OnTriggerStay()
    {
        if (throttle > 0.01f)
        {
            dirt.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Ship"))
        if (throttle < 0.01f)
        {
            dirt.Stop();   
        }
    }
}