using UnityEngine;

public class RocketAttachment : MonoBehaviour
{
    public Transform rocketTransform; // assign this in the Inspector
    public Vector3 attachmentOffset; // offset from the ship where the rocket should be attached

    private void LateUpdate()
    {
        // move the empty GameObject to the ship's position and rotation
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;

        // move the rocket to the attachment point with the offset
        rocketTransform.position = transform.position + attachmentOffset;
        rocketTransform.rotation = transform.rotation;
    }
}
