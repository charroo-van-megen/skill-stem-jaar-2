using UnityEngine;

public class InfiniteBounce : MonoBehaviour
{
    public float speed = 5f;          // Speed of the ball
    private Vector2 velocity;         // Current movement vector
    private float yLimit = 4.5f;      // Top/bottom boundary (adjust based on your camera size)

    void Start()
    {
        // Start moving upward-right
        velocity = new Vector2(speed, speed);
    }

    void Update()
    {
        // Move the ball
        transform.Translate(velocity * Time.deltaTime);

        // Check top/bottom bounds and bounce
        if (transform.position.y > yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit, 0);
            velocity.y *= -1;
        }
        else if (transform.position.y < -yLimit)
        {
            transform.position = new Vector3(transform.position.x, -yLimit, 0);
            velocity.y *= -1;
        }

        // Optional: bounce left/right too
        float xLimit = 8f;
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, 0);
            velocity.x *= -1;
        }
        else if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, 0);
            velocity.x *= -1;
        }
    }
}
