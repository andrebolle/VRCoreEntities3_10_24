using UnityEngine;
using UnityEngine.Splines;

public class AlienFormation : MonoBehaviour
{
    public GameObject alienPrefab;  // Reference to the alien prefab
    public int alienCount = 11;     // Number of aliens per row
    public float movementSpeed = 2.0f;  // Speed at which aliens move along the spline

    private SplineContainer splineContainer;
    private GameObject[] aliens;

    void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
        if (splineContainer == null)
        {
            Debug.LogError("SplineContainer not found on this GameObject.");
            return;
        }

        aliens = new GameObject[alienCount];

        // Instantiate and position aliens along the spline
        for (int i = 0; i < alienCount; i++)
        {
            float normalizedPosition = i / (float)(alienCount - 1); // Evenly space between 0 and 1
            Vector3 position = splineContainer.EvaluatePosition(normalizedPosition);

            aliens[i] = Instantiate(alienPrefab, position, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * movementSpeed, 1f);

        for (int i = 0; i < alienCount; i++)
        {
            float normalizedPosition = i / (float)(alienCount - 1);
            float newT = Mathf.Clamp01(normalizedPosition + t * 0.1f);

            Vector3 newPosition = splineContainer.EvaluatePosition(newT);
            aliens[i].transform.position = newPosition;
        }
    }
}
