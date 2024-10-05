using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float length = 2.0f; // Length of the pendulum
    public float gravity = 9.81f; // Gravitational force
    public float angle = 30.0f; // Initial angle in degrees
    public float damping = 0.999f; // Damping factor to slow down the swing over time

    private float angularVelocity = 0.0f; // Current angular velocity
    private float currentAngle; // Current angle in radians

    void Start()
    {
        // Convert initial angle from degrees to radians
        currentAngle = angle * Mathf.Deg2Rad;
    }

    void Update()
    {
        // Physics calculation for angular acceleration
        float angularAcceleration = (-gravity / length) * Mathf.Sin(currentAngle);

        // Update the angular velocity (adding damping to gradually slow it down)
        angularVelocity += angularAcceleration * Time.deltaTime;
        angularVelocity *= damping;

        // Update the current angle based on the velocity
        currentAngle += angularVelocity * Time.deltaTime;

        // Convert the current angle back to degrees and rotate the pendulum bar
        float rotationAngle = currentAngle * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
