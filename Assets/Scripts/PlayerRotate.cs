using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    // Duration of the rotation in seconds
    public float rotationDuration = 1f;
    bool hasTriggered = false;

    // This method is called when the collider enters another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a specific tag (optional)
        if (other.gameObject.CompareTag("Rotator") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(RotateSmoothly(90f)); // Rotate 90 degrees
        }
    }

    private IEnumerator RotateSmoothly(float angle)
    {
        // Calculate the target rotation
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, angle, 0);

        // Track elapsed time
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            // Interpolate between the current rotation and the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (elapsedTime / rotationDuration));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until next frame
        }

        // Ensure the final rotation is set to the target rotation
        transform.rotation = targetRotation;
    }
}
