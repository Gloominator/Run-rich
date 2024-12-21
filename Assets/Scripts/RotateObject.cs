using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        // Calculate the rotation amount for this frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate around the object's local axis (e.g., Y-axis)
        transform.Rotate(0, rotationAmount, 0);
    }
}
