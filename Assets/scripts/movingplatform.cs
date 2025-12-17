using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] points;

    private int i = 0;

    void Start()
    {
        transform.position = points[0].position;
    }

    void Update()
    {
        // Move platform to the next point
        transform.position = Vector2.MoveTowards(
            transform.position,
            points[i].position,
            speed * Time.deltaTime
        );

        // Check if the platform reached the current point
        if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            i++;

            // Loop back to the first point
            if (i == points.Length)
            {
                i = 0;
            }
        }
    }
}
