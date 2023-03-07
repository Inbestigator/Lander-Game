using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 90f;

    void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the direction to move based on input
        Vector3 moveDirection = Quaternion.AngleAxis(0, Vector3.up) * transform.right * verticalInput;

        // Apply movement
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Calculate the amount to turn based on input
        float turnAmount = horizontalInput * turnSpeed * Time.deltaTime;

        // Rotate the boat
        transform.Rotate(Vector3.up, turnAmount, Space.World);
    }
}
