using UnityEngine;
using UnityEngine.Splines;

public class AlienMover : MonoBehaviour
{
    public Spline spline;
    public float startT;
    public float speed;

    private float t;
    private bool forward = true;

    void Update()
    {
        if (forward)
            t += speed * Time.deltaTime;
        else
            t -= speed * Time.deltaTime;

        // Ping-pong the value of t between 0 and 1
        if (t >= 1f)
        {
            t = 1f;
            forward = false;
        }
        else if (t <= 0f)
        {
            t = 0f;
            forward = true;
        }

        // Update the alien's position along the spline
        Vector3 position = spline.EvaluatePosition(t);
        transform.position = position;
    }

    void Start()
    {
        t = startT;
    }
}
