using UnityEngine;
using UnityEngine.Splines;

public class AlienSpawner : MonoBehaviour
{
    public GameObject alienPrefab; // Assign your alien prefab here
    public int numberOfAliens = 11;
    public float speed = 2f;

    private Spline spline;

    void Start()
    {
        spline = GetComponent<SplineContainer>().Spline;

        for (int i = 0; i < numberOfAliens; i++)
        {
            // Calculate a normalized position along the spline
            float t = (float)i / (numberOfAliens - 1);

            // Get the position on the spline
            Vector3 position = spline.EvaluatePosition(t);

            // Instantiate the alien
            GameObject alien = Instantiate(alienPrefab, position, Quaternion.identity, transform);

            // Add the AlienMover component
            AlienMover mover = alien.AddComponent<AlienMover>();
            mover.spline = spline;
            mover.startT = t;
            mover.speed = speed;
        }
    }
}
