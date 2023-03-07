using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float thrust;
    public float maxThrust;
    public float throttle;
    public float position;
    public float tilt;
    public float rotation;
    public float gravity;
    public float tiltSpeed;
    public float rotationSpeed;

    public Renderer flames;

    public Transform thrustPoint;
    public Transform tiltPoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();

        if (throttle > 0.0)
        {
            flames.enabled = true;
        } 
        else 
        {
            flames.enabled = false;
        }
    }

    void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }

    void HandleInput()
    {
        // Handle throttle control
        float throttleInput = 0.0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            throttleInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            throttleInput = -1.0f;
        }
        throttle += throttleInput * Time.deltaTime;
        throttle = Mathf.Clamp(throttle, 0.0f, maxThrust);

        // Handle instant max throttle and zero throttle
        if (Input.GetKeyDown(KeyCode.Z))
        {
            throttle = maxThrust;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            throttle = 0.0f;
        }

        // Handle rotation control
        float rotationInput = 0.0f;
        if (Input.GetKey(KeyCode.E))
        {
            rotationInput = 0.05f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotationInput = -0.05f;
        }
        Vector3 rotationForce = transform.up * rotationInput * rotationSpeed;
        rb.AddTorque(rotationForce, ForceMode.Acceleration);

        // Handle tilt control
        float tiltInput = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            tiltInput = -0.7f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            tiltInput = 0.7f;
        }
        Vector3 tiltForce = tiltPoint.forward * tiltInput * tiltSpeed;
        rb.AddForceAtPosition(tiltForce, thrustPoint.position, ForceMode.Acceleration);

        // // Handle gravity control
        // if (Input.GetKey(KeyCode.G))
        // {
        //     gravity += Time.deltaTime * 0.1f;
        // }
        // else if (Input.GetKey(KeyCode.H))
        // {
        //     gravity -= Time.deltaTime * 0.1f;
        //     gravity = Mathf.Max(0.0f, gravity);
        // }
    }

    void HandleThrust()
    {
        Vector3 thrustForce = transform.up * throttle * thrust;
        rb.AddForce(thrustForce, ForceMode.Acceleration);
    }

    void HandleRotation()
    {
        // Handle pitch and yaw rotation
        float pitchInput = Input.GetAxis("Vertical");
        float yawInput = Input.GetAxis("Horizontal");
        Vector3 rotationForce = new Vector3(pitchInput, yawInput, 0.0f) * rotationSpeed;
        rb.AddRelativeTorque(rotationForce, ForceMode.Acceleration);

        // Handle roll rotation
        // float rollInput = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            yawInput = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            yawInput = 1.0f;
        }
        Vector3 yawForce = tiltPoint.right * yawInput * tiltSpeed;
        rb.AddForceAtPosition(yawForce, thrustPoint.position, ForceMode.Acceleration);
    }


    public float GetThrottle()
    {
        return throttle;
    }

    public float GetTilt()
    {
        return tilt;
    }

    public float GetRotation()
    {
        return rotation;
    }

    public float GetPosition()
    {
        return position;
    }
}

