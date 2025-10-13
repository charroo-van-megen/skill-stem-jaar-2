using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpingBlock2D : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 6f;   // How strong the jump is
    [SerializeField] float jumpInterval = 1.5f; // How often the block jumps (in seconds)
    Rigidbody2D rb;
    float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;   // Makes jump arcs look natural
        rb.freezeRotation = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= jumpInterval)
        {
            Jump();
            timer = 0f;
        }
    }

    void Jump()
    {
        // Reset vertical velocity before applying force
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
