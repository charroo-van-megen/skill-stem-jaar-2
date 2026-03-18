using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 5f;

    private float screenWidth;

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        // Snelheid aanpassen
        if (Input.GetKey(KeyCode.W))
            speed += acceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            speed -= acceleration * Time.deltaTime;

        // Auto bewegen
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Wrap around screen
        if (transform.position.x > screenWidth + 1f)
            transform.position = new Vector2(-screenWidth - 1f, transform.position.y);
    }
}