// Once

//using UnityEngine;
//using UnityEngine.Splines;

//public class MoveAlongSpline : MonoBehaviour
//{
//    public SplineContainer splineContainer; // Drag your Spline here in the Inspector
//    public float speed = 5f; // Speed of movement along the spline

//    private float t = 0f; // Normalized time along the spline (0 to 1)

//    void Update()
//    {
//        // Increment time based on speed
//        t += Time.deltaTime * speed / splineContainer.CalculateLength();

//        // Keep t within bounds (0 to 1)
//        t = Mathf.Clamp01(t);

//        // Get the position along the spline based on t
//        Vector3 position = splineContainer.EvaluatePosition(t);

//        // Move the object to that position
//        transform.position = position;
//    }
//}

// Ping Pong

using UnityEngine;
using UnityEngine.Splines;

public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer splineContainer; // Drag your Spline here in the Inspector
    public float speed = 5f; // Speed of movement along the spline

    private float t = 0f; // Normalized time along the spline (0 to 1)
    private bool reverse = false; // Direction of movement

    void Update()
    {
        // Calculate movement time based on direction
        float delta = Time.deltaTime * speed / splineContainer.CalculateLength();
        t += reverse ? -delta : delta;

        // Switch direction when reaching the end of the spline
        if (t >= 1f)
        {
            t = 1f;
            reverse = true; // Start moving backwards
        }
        else if (t <= 0f)
        {
            t = 0f;
            reverse = false; // Start moving forwards
        }

        // Get the position along the spline based on t
        Vector3 position = splineContainer.EvaluatePosition(t);

        // Move the object to that position
        transform.position = position;
    }
}
