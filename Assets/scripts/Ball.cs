using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class BouncingBall2D : MonoBehaviour
{
    [Header("Ball Settings")]
    [SerializeField] float bounceForce = 8f;   // Strength of the upward bounce
    [SerializeField] float horizontalSpeed = 3f; // Optional sideways movement
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Configure physics for perfect, endless bounce
        rb.gravityScale = 1f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;

        // Create a physics material for infinite bounciness
        PhysicsMaterial2D bounceMat = new PhysicsMaterial2D("PerfectBounce");
        bounceMat.bounciness = 1f;
        bounceMat.friction = 0f;
        GetComponent<CircleCollider2D>().sharedMaterial = bounceMat;

        // Give the ball an initial motion
        rb.linearVelocity = new Vector2(horizontalSpeed, bounceForce);
    }

    void FixedUpdate()
    {
        // Keep horizontal speed constant (so it doesn't slow down over time)
        rb.linearVelocity = new Vector2(horizontalSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reinforce bounce — ensures energy never decays
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
    }
}
