using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    void HandleRotation()
    {
        float rotationInput = 0f;

        if (Input.GetKey(KeyCode.A))
            rotationInput = 1f;
        else if (Input.GetKey(KeyCode.D))
            rotationInput = -1f;

        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotation);
    }

    void HandleMovement()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.W))
            moveInput = 1f;
        else if (Input.GetKey(KeyCode.S))
            moveInput = -1f;

        Vector2 movement = transform.up * moveInput * moveSpeed;

        rb.linearVelocity = movement;
    }
}