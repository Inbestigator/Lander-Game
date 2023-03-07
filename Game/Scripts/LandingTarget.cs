using UnityEngine;

public class LandingTarget : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform rocket;
    public float circleRadius = 10f;
    public float yOffset = 0.1f;

    private Vector3 circlePosition;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(rocket.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            circlePosition = hit.point + Vector3.up * yOffset;
            transform.position = circlePosition;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(circlePosition, circleRadius);
    }
}
