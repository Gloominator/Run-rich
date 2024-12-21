using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerTrigger : MonoBehaviour
{
    // Duration of the rotation in seconds
    public float rotationDuration = 0.5f;
    bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "Player"
        if (other.CompareTag("Player") && !hasTriggered)
        {
           hasTriggered = true;
            StartCoroutine(RotateSmoothly(other.transform, 90f)); // Rotate 90 degrees
        }
    }

    private IEnumerator RotateSmoothly(Transform playerTransform, float angle)
    {
        // Calculate the target rotation
        Quaternion targetRotation = playerTransform.rotation * Quaternion.Euler(0, angle, 0);

        // Track elapsed time
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            // Interpolate between the current rotation and the target rotation
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, (elapsedTime / rotationDuration));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until next frame
        }

        // Ensure the final rotation is set to the target rotation
        playerTransform.rotation = targetRotation;
    }
}
