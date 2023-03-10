using UnityEngine;

public class PlumeController : MonoBehaviour
{
    public ParticleSystem[] plumes; // assign these in the Inspector
    public Light[] lights; // assign these in the Inspector
    public float maxEmissionRate = 100f;
    public float maxIntensity = 10f;
    public RocketController control; // set this using code
    public float throttle;

    private void Update()
    {
        throttle = control.throttle;
        for (int i = 0; i < plumes.Length; i++)
        {
            var emission = plumes[i].emission;
            emission.rateOverTime = throttle * maxEmissionRate;

            if (i < lights.Length)
            {
                lights[i].intensity = throttle * maxIntensity;
            }
        }
    }
}
