using UnityEngine;

public class RocketAttachment : MonoBehaviour
{
    public Transform rocketTransform; // assign this in the Inspector
    public Transform emptPos;
    public Vector3 attachmentOffset; // offset from the ship where the rocket should be attached
    public Vector3 touchdown;

    private void OnEnable()
    {
        rocketTransform.SetParent(transform, true); // make the rocket a child of the ship
        touchdown = emptPos.position - rocketTransform.position;
        attachmentOffset = new Vector3(rocketTransform.position.x, 11.07f, rocketTransform.position.z);

        // Check if rocket is too far away on Z axis
        if (Mathf.Abs(touchdown.z) > 6f)
        {
            attachmentOffset.z = Mathf.Sign(touchdown.z) * -6f;
        }

        // Check if rocket is too far away on X axis
        if (Mathf.Abs(touchdown.x) > 10f)
        {
            attachmentOffset.x = Mathf.Sign(touchdown.x) * -10f;
        }

        // move the rocket to the attachment point with the offset
        rocketTransform.position = attachmentOffset;

        // set the rocket's rotation to be the same as the ship's rotation except for the Y component
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rocketTransform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        rocketTransform.rotation = newRotation;

        rocketTransform.localScale = Vector3.Scale(rocketTransform.localScale, new Vector3(1f / transform.localScale.x, 1f / transform.localScale.y, 1f / transform.localScale.z));
    }


}
