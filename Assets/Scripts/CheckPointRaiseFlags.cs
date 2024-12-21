using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointRaiseFlags : MonoBehaviour
{
    public Transform object1; // Assign your first object in the Inspector
    public Transform object2; // Assign your second object in the Inspector
    public float duration = 1f; // Time in seconds to complete the rotation
    bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(RotateObjectsToZeroZ());
        }
    }
    

    private IEnumerator RotateObjectsToZeroZ()
    {
        // Get initial rotations
        Vector3 initialRotation1 = object1.rotation.eulerAngles;
        Vector3 initialRotation2 = object2.rotation.eulerAngles;

        // Target Z rotation
        float targetZRotation = 0f;

        // Calculate the total number of steps based on duration and frame rate
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime; // Increment elapsed time

            // Calculate the proportion of time passed
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate only the Z rotation while keeping X and Y unchanged
            Vector3 newRotation1 = new Vector3(initialRotation1.x, initialRotation1.y, Mathf.LerpAngle(initialRotation1.z, targetZRotation, t));
            Vector3 newRotation2 = new Vector3(initialRotation2.x, initialRotation2.y, Mathf.LerpAngle(initialRotation2.z, targetZRotation, t));

            // Apply the new rotations back to the objects
            object1.rotation = Quaternion.Euler(newRotation1);
            object2.rotation = Quaternion.Euler(newRotation2);

            yield return null; // Wait for the next frame
        }

        // Ensure final Z rotation is exactly zero while keeping X and Y unchanged
        Vector3 finalRotation1 = object1.rotation.eulerAngles;
        Vector3 finalRotation2 = object2.rotation.eulerAngles;
        finalRotation1.z = 0f;
        finalRotation2.z = 0f;

        object1.rotation = Quaternion.Euler(finalRotation1);
        object2.rotation = Quaternion.Euler(finalRotation2);
    }
}
